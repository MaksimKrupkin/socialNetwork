using api.Dtos;
using api.Models;
using System.Linq;

namespace api.Mappers
{
    public static class MessageMapper
    {
        // Маппинг из Message в MessageDto
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

        // Маппинг из MessageDto в Message
        public static Message ToMessageModel(MessageDto messageDto)
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