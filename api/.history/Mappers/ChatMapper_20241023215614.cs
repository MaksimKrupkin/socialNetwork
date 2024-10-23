using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class ChatMapper
    {
        public static ChatDto ToChatDto(Chat chat)
        {
            return new ChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                Messages = chat.Messages.Select(m => new MessageDto
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    ChatId = m.ChatId,
                    Content = m.Content,
                    SentAt = m.SentAt
                }).ToList()
            };
        }

        public static Chat ToChatModel(ChatDto chatDto)
        {
            return new Chat
            {
                Id = chatDto.Id,
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select(m => new Message
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    ChatId = m.ChatId,
                    Content = m.Content,
                    SentAt = m.SentAt
                }).ToList()
            };
        }
    }
}