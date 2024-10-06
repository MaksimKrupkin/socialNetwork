using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Dtos;
using api.Interfaces;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        // Конструктор с внедрением репозитория
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Получить всех пользователей
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = users.Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                CreatedAt = user.CreatedAt,
                BirthDay = user.BirthDay
            }).ToList();
            return Ok(usersDto);
        }

        // Получить пользователя по ID
        [HttpGet("{id}")]
public async Task<ActionResult<UserWithDetailsDto>> GetUserById(int id)
{
    var user = await _userRepository.GetByIdAsync(id);

    if (user == null)
    {
        return NotFound();
    }

    var userWithDetailsDto = new UserWithDetailsDto
    {
        Id = user.Id,
        Email = user.Email,
        Bio = user.Bio,
        ProfileImageUrl = user.ProfileImageUrl,
        CreatedAt = user.CreatedAt,
        BirthDay = user.BirthDay,
        Chats = user.AllChats.Select(chat => new ChatDto
        {
            Id = chat.Id,
            User1Id = chat.User1Id,
            User2Id = chat.User2Id,
            CreatedAt = chat.CreatedAt,
            Messages = chat.Messages.Select(message => new MessageDto
            {
                Id = message.Id,
                Content = message.Content,
                SentAt = message.SentAt  // Используем SentAt вместо CreatedAt
            }).ToList()
        }).ToList(),
        Posts = user.Posts.Select(post => new PostDto
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        }).ToList(),
        Followers = user.Followers.Select(f => new UserDto
        {
            Id = f.FollowerId,
            Email = f.Follower.Email
        }).ToList(),
        Following = user.Following.Select(f => new UserDto
        {
            Id = f.FolloweeId,
            Email = f.Followee.Email
        }).ToList()
    };

    return Ok(userWithDetailsDto);
}

        // Создать нового пользователя
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Email = createUserDto.Email,
                Bio = createUserDto.Bio,
                ProfileImageUrl = createUserDto.ProfileImageUrl,
                BirthDay = createUserDto.BirthDay,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password) // Хеширование пароля
            };

            var createdUser = await _userRepository.CreateAsync(user);

            var userDto = new UserDto
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                Bio = createdUser.Bio,
                ProfileImageUrl = createdUser.ProfileImageUrl,
                CreatedAt = createdUser.CreatedAt,
                BirthDay = createdUser.BirthDay
            };

            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        // Обновить существующего пользователя
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = new User
            {
                Email = updateUserDto.Email,
                Bio = updateUserDto.Bio,
                ProfileImageUrl = updateUserDto.ProfileImageUrl,
                BirthDay = updateUserDto.BirthDay,
                PasswordHash = !string.IsNullOrEmpty(updateUserDto.Password) ? BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password) : null
            };

            var updatedUser = await _userRepository.UpdateAsync(id, user);

            if (updatedUser == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                Bio = updatedUser.Bio,
                ProfileImageUrl = updatedUser.ProfileImageUrl,
                CreatedAt = updatedUser.CreatedAt,
                BirthDay = updatedUser.BirthDay
            };

            return Ok(userDto);
        }

        // Удалить пользователя
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userRepository.DeleteAsync(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}