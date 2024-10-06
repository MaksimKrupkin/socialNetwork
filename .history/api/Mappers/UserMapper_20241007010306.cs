using api.Models;
using api.Dtos;

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
                BirthDay = user.BirthDay
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
                Chats = user.AllChats.Select(c => new ChatDto
                {
                    Id = c.Id,
                    User1Id = c.User1Id,
                    User2Id = c.User2Id,
                    CreatedAt = c.CreatedAt,
                    Messages = c.Messages.Select(m => new MessageDto
                    {
                        Id = m.Id,
                        Content = m.Content,
                        SentAt = m.SentAt
                    }).ToList()
                }).ToList(),
                Posts = user.Posts.Select(p => new PostDto
                {
                    Id = p.Id,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt
                }).ToList(),
                Followers = user.Followers.Select(f => f.Follower.ToUserDto()).ToList(),
                Following = user.Following.Select(f => f.Followee.ToUserDto()).ToList()
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
        BirthDay = DateTime.SpecifyKind(createUserDto.BirthDay, DateTimeKind.Utc), // Set to UTC
        PasswordHash = createUserDto.Password // Make sure to hash this properly
    };
}

        public static void ToUserFromUpdateDTO(this UpdateUserDto updateUserDto, User user)
{
    user.Email = updateUserDto.Email;
    user.Bio = updateUserDto.Bio;
    user.ProfileImageUrl = updateUserDto.ProfileImageUrl;
    user.BirthDay = DateTime.SpecifyKind(updateUserDto.BirthDay, DateTimeKind.Utc); // Set to UTC

    if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
    {
        user.PasswordHash = updateUserDto.Password; // Hash this password as well
    }
}
    }
}