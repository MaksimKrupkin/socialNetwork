using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto? ToMessageDto(Message? message)
        {
            if (message == null) return null;

            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                Content = message.Content,
                SentAt = message.SentAt,
                User1Id = message.ChatId, // Assuming mapping for ChatId to User1Id/User2Id as placeholders
                User2Id = message.ChatId
            };
        }

        public static Message ToMessageModel(CreateMessageDto createMessageDto)
        {
            return new Message
            {
                SenderId = createMessageDto.SenderId,
                ChatId = createMessageDto.User1Id, // Assuming User1Id or User2Id maps to ChatId
                Content = createMessageDto.Content,
                SentAt = createMessageDto.SentAt
            };
        }
    }
}