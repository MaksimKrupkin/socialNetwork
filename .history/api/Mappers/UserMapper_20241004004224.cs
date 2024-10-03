using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos;
using BCrypt.Net;

namespace api.Mappers
{
    public class UserMapper
    {
        // Метод для маппинга User -> UserDto
        public static UserDto ToUserDto(User user)
        {
          if (user == null) return null;

          return new UserDto
          {
            Id = user.Id,
            Email = user.Email,
            Bio = user.Bio,
            ProfileImageUrl = user.ProfileImageUrl,
            CreatedAt = user.CreatedAt,
            BirthDay = user.BirthDay
          };
        }

        // Метод для маппинга CreateUserDto -> User
        public static User ToUser(CreateUserDto createUserDto)
        {
          if (createUserDto == null) return null;

          return new User
          {
            Email = createUserDto.Email,
            Bio = createUserDto.Bio,
            ProfileImageUrl = createUserDto.ProfileImageUrl,
            BirthDay = createUserDto.BirthDay,
            PasswordHash = HashPassword(createUserDto.Password) // Добавьте метод хеширования пароля
          };
        }

        // Метод для маппинга UpdateUserDto -> User (обновление существующего пользователя)
         public static void UpdateUser(User user, UpdateUserDto updateUserDto)
        {
            if (user == null || updateUserDto == null) return;

            user.Email = updateUserDto.Email;
            user.Bio = updateUserDto.Bio;
            user.ProfileImageUrl = updateUserDto.ProfileImageUrl;
            user.BirthDay = updateUserDto.BirthDay;

            // Если новый пароль не пустой, обновляем пароль
            if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
            {
                user.PasswordHash = HashPassword(updateUserDto.Password);
            }
        }
        // Метод для маппинга User -> UserWithDetailsDto
        public static UserWithDetailsDto ToUserWithDetailsDto(User user)
        {
            if (user == null) return null;

            return new UserWithDetailsDto
            {
                Id = user.Id,
                Email = user.Email,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                CreatedAt = user.CreatedAt,
                BirthDay = user.BirthDay,
                Chats = user.AllChats?.Select(chat => ChatMapper.ToChatDto(chat)).ToList(), // Пример использования ChatMapper
                Posts = user.Posts?.Select(post => PostMapper.ToPostDto(post)).ToList(), // Пример использования PostMapper
                Followers = user.Followers?.Select(f => ToUserDto(f.Follower)).ToList(),
                Following = user.Following?.Select(f => ToUserDto(f.Followee)).ToList()
            };
        }
            // Пример метода хеширования пароля
        private static string HashPassword(string password)
        {
            // Здесь вы можете использовать свою логику хеширования
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}