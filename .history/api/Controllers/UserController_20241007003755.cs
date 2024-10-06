using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Repository;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepo;

        public UserController(ApplicationDbContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var users = await _userRepo.GetAllAsync();
            var userDtos = users.Select(u => u.ToUserDto());
            return Ok(userDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user.ToUserWithDetailsDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userModel = createUserDto.ToUserFromCreateDTO();
            await _userRepo.CreateAsync(userModel);
            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
        }

       [HttpPut("{id:int}")]
public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateDto)
{
    if (!ModelState.IsValid) return BadRequest(ModelState);

    // Получаем существующего пользователя из базы данных
    var userModel = await _userRepo.GetByIdAsync(id);

    if (userModel == null)
    {
        return NotFound();
    }

    // Передаем существующего пользователя в метод преобразования
    updateDto.ToUserFromUpdateDTO(userModel); 

    // Обновляем пользователя в базе данных
    await _userRepo.UpdateAsync(id, userModel);

    return Ok(userModel.ToUserDto());
}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userModel = await _userRepo.DeleteAsync(id);
            if (userModel == null) return NotFound();
            return NoContent();
        }
    }
}