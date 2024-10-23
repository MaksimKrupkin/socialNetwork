using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class MessageMapper
    {
        // Mapping from Message to MessageDto
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

        // Mapping from CreateMessageDto to Message (no Id)
        public static Message ToMessageModel(CreateMessageDto createMessageDto)
        {
            return new Message
            {
                SenderId = createMessageDto.SenderId,
                Content = createMessageDto.Content,
                SentAt = createMessageDto.SentAt
            };
        }

        // Mapping from MessageDto to Message (for updating)
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