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
                ChatId = message.ChatId, // Убедитесь, что используете ChatId
                Content = message.Content,
                SentAt = message.SentAt,
                ChatUser1Id = message.ChatUser1Id, // Ссылка на User1, если нужно
                ChatUser2Id = message.ChatUser2Id  // Ссылка на User2, если нужно
            };
        }

    public static Message ToMessageModel(MessageDto messageDto)
        {
            if (messageDto == null) return null;

            return new Message
            {
                Id = messageDto.Id,
                SenderId = messageDto.SenderId,
                ChatId = messageDto.ChatId, // Используйте ChatId
                Content = messageDto.Content,
                SentAt = messageDto.SentAt,
                ChatUser1Id = messageDto.ChatUser1Id, // Если нужно
                ChatUser2Id = messageDto.ChatUser2Id  // Если нужно
            };
        }
}
}
