using System;
using System.Collections.Generic;

namespace api.Dtos
{
    public class ChatDto
    {
        public int User1Id { get; set; } // Идентификатор первого пользователя
        public int User2Id { get; set; } // Идентификатор второго пользователя
        public DateTime CreatedAt { get; set; } // Дата создания чата
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>(); // Сообщения в чате
    }
}