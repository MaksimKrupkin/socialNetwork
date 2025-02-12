using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Models;
using System.Security.Cryptography;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded
                ? Ok(new { message = "Пользователь успешно зарегистрирован" })
                : BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized("Invalid credentials");

            await UpdateRefreshToken(user);
            
            return Ok(new TokenModel
            {
                AccessToken = GenerateJwtToken(user),
                RefreshToken = user.RefreshToken
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModel tokenModel)
        {
            if (tokenModel is null)
                return BadRequest("Invalid client request");

            var principal = GetPrincipalFromExpiredToken(tokenModel.AccessToken);
    
            // Добавляем логирование
            Console.WriteLine($"All claims in principal:");
            foreach (var claim in principal.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }

            var userIdClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier) 
                              ?? principal.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (string.IsNullOrEmpty(userIdClaim))
                return BadRequest("User ID claim (sub) is missing in token");

            if (!int.TryParse(userIdClaim, out var userId))
                return BadRequest($"Invalid user ID format: '{userIdClaim}'");

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null || 
                user.RefreshToken != tokenModel.RefreshToken || 
                user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return BadRequest("Invalid refresh token");

            await UpdateRefreshToken(user);
            
            return Ok(new TokenModel
            {
                AccessToken = GenerateJwtToken(user),
                RefreshToken = user.RefreshToken
            });
        }

        private async Task UpdateRefreshToken(User user)
        {
            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(
                Convert.ToDouble(_configuration["Jwt:RefreshTokenLifetime"]));
            await _userManager.UpdateAsync(user);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                // Логируем значения из токена
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken != null)
                {
                    Console.WriteLine($"Token Issuer: {jwtSecurityToken.Issuer}");
                    Console.WriteLine($"Token Audience: {jwtSecurityToken.Audiences.FirstOrDefault()}");
                }

                if (securityToken is not JwtSecurityToken jwtToken || 
                    (!jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase) &&
                     !jwtToken.Header.Alg.Equals("http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", StringComparison.InvariantCultureIgnoreCase)))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            catch (Exception ex)
            {
                // Логирование ошибок
                Console.WriteLine($"Error while validating token: {ex.Message}");
                throw new SecurityTokenException("Token validation failed", ex);
            }
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var credentials = new SigningCredentials(
                key, 
                SecurityAlgorithms.HmacSha256
            );

            // Используем единый стандарт для claims
            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Добавляем стандартный claim
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"], // Исправьте опечатку (Audience)
                claims: claims,
                expires: DateTime.UtcNow.AddHours(
                    Convert.ToDouble(_configuration["Jwt:AccessTokenLifetime"])),
                signingCredentials: credentials
            );
    
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}