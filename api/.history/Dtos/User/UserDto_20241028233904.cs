using System;
using System.Collections.Generic;

namespace api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BirthDay { get; set; }

        // Добавление свойств для чатов
        public List<ChatDto> ChatsAsUser1 { get; set; } = new List<ChatDto>();
        public List<ChatDto> ChatsAsUser2 { get; set; } = new List<ChatDto>();
    }
}