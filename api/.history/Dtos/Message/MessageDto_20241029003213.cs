using System;

namespace api.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ChatUser1Id { get; set; } // Добавьте это свойство
        public int ChatUser2Id { get; set; } // Добавьте это свойство
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}