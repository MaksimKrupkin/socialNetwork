using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class CreateChatDto
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
    }

    public class ChatDto : CreateChatDto
    {
        public int Id { get; set; } // Добавляем Id только для чтения
    }
}