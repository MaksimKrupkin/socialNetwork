using api.Models;
using api.Dtos;
using System.Linq;

namespace api.Mappers
{
    public static class UserMapper
    {
        // Преобразование User в UserDto
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                CreatedAt = user.CreatedAt,
                BirthDay = user.BirthDay,
                UserName  = user.UserName 
            };
        }

        // Преобразование User в UserWithDetailsDto
        public static UserWithDetailsDto ToUserWithDetailsDto(this User user)
        {
            return new UserWithDetailsDto
            {
                Id = user.Id,
                Email = user.Email,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                CreatedAt = user.CreatedAt,
                BirthDay = user.BirthDay,
                Chats = user.AllChats?.Select(c => new ChatDto
                {
                    // Удалите Id, так как Chat не имеет отдельного идентификатора
                    User1Id = c.User1Id,
                    User2Id = c.User2Id,
                    CreatedAt = c.CreatedAt,
                    Messages = c.Messages?.Select(m => new MessageDto
                    {
                        Id = m.Id, // Если Message имеет свой Id
                        Content = m.Content,
                        SentAt = m.SentAt
                    }).ToList() ?? new List<MessageDto>()
                }).ToList() ?? new List<ChatDto>(),
                Posts = user.Posts?.Select(p => new PostDto
                {
                    Id = p.Id,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt
                }).ToList() ?? new List<PostDto>(),
                Followers = user.Followers?.Select(f => f.Follower.ToUserDto()).ToList() ?? new List<UserDto>(),
                Following = user.Following?.Select(f => f.Followee.ToUserDto()).ToList() ?? new List<UserDto>()
            };
        }

        // Преобразование CreateUserDto в User
        public static User ToUserFromCreateDTO(this CreateUserDto createUserDto)
        {
            return new User
            {
                Email = createUserDto.Email,
                Bio = createUserDto.Bio,
                ProfileImageUrl = createUserDto.ProfileImageUrl,
                BirthDay = createUserDto.BirthDay,
                UserName  = createUserDto.UserName ,
                PasswordHash = createUserDto.Password
            };
        }

        public static void ToUserFromUpdateDTO(this UpdateUserDto updateUserDto, User user)
        {
            user.Email = updateUserDto.Email;
            user.Bio = updateUserDto.Bio;
            user.ProfileImageUrl = updateUserDto.ProfileImageUrl;
            user.BirthDay = DateTime.SpecifyKind(updateUserDto.BirthDay, DateTimeKind.Utc);

            if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
            {
                user.PasswordHash = updateUserDto.Password; // Не забудьте хешировать пароль
            }
        }
    }
}