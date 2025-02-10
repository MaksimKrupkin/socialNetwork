using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        public int User1Id { get; set; } // First user identifier
        public int User2Id { get; set; } // Second user identifier
    }

    public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}