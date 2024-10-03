using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class ChatDto
    {
      public int Id { get; set; }
      public int User1Id { get; set; }
      public int User2Id { get; set; }
      public DateTime CreatedAt { get; set; }
      public List<MessageDto> Messages { get; set; } // Маппинг для сообщений
    }
}