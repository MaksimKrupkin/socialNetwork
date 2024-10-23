using System;
using System.Collections.Generic;

namespace api.Dtos
{
    // Main DTO for message representation
    public class MessageDto
    {
        public int Id { get; set; } // This ID will be auto-generated
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } // SentAt can be set in the controller during creation
    }

    // DTO for creating a new message (without the Id and ChatId)
    public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } // Optional: Can also be set to DateTime.UtcNow in the controller
    }
}