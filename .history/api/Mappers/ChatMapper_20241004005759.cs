using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Mappers
{
    public class ChatMapper
    {
      public static ChatDto ToChatDto(Chat chat)
      {
          return new ChatDto
          {
              Id = chat.Id,
              User1Id = chat.User1Id,
              User2Id = chat.User2Id,
              CreatedAt = chat.CreatedAt,
              Messages = chat.Messages?.Select(MessageMapper.ToMessageDto).ToList()
          };
      }
      
      public static Chat ToChat(ChatDto chatDto)
      {
          return new Chat
          {
              Id = chatDto.Id,
              User1Id = chatDto.User1Id,
              User2Id = chatDto.User2Id,
              CreatedAt = chatDto.CreatedAt                
              // Сообщения также обычно управляются отдельно
          };
      }
  }
}