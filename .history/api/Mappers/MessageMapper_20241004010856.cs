using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public class MessageMapper
    {
        public static MessageDto ToMessageDto(Message message)
        {
            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ChatId = message.ChatId,
                Content = message.Content,
                SentAt = message.SentAt
            };
        }

        public static Message ToMessage(MessageDto messageDto)
        {
            return new Message
            {
                Id = messageDto.Id,
                SenderId = messageDto.SenderId,
                ChatId = messageDto.ChatId,
                Content = messageDto.Content,
                SentAt = messageDto.SentAt
            };
        }
    }
}