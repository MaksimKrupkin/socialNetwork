using System;

namespace api.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; } // Добавлено свойство ChatId
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
        public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public int ChatUser1Id { get; set; }
        public int ChatUser2Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}