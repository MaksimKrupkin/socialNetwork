using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto ToMessageDto(Message message)
        {
            if (message == null) return null;

            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                Content = message.Content,
                SentAt = message.SentAt,
                User1Id = message.User1Id,
                User2Id = message.User2Id
            };
        }

        public static Message ToMessageModel(CreateMessageDto createMessageDto)
        {
            return new Message
            {
                SenderId = createMessageDto.SenderId,
                User1Id = createMessageDto.User1Id,
                User2Id = createMessageDto.User2Id,
                Content = createMessageDto.Content,
                SentAt = createMessageDto.SentAt
            };
        }
    }
}