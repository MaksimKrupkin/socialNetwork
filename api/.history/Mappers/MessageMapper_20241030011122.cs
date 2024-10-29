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

public static Message ToMessageModel(CreateMessageDto createMessageDto)
{
    return new Message
    {
        SenderId = createMessageDto.SenderId,
        ChatUser1Id = createMessageDto.ChatUser1Id,
        ChatUser2Id = createMessageDto.ChatUser2Id,
        Content = createMessageDto.Content,
        SentAt = createMessageDto.SentAt
    };
}
}
}
