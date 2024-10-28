using System;

namespace api.Dtos
{
public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; } // Убедитесь, что это свойство есть
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // Добавьте свойства ChatUser1Id и ChatUser2Id, если они нужны
        public int ChatUser1Id { get; set; } // Идентификатор первого пользователя
        public int ChatUser2Id { get; set; } // Идентификатор второго пользователя
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