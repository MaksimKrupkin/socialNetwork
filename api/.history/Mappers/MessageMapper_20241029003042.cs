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
            ChatUser1Id = message.ChatUser1Id,
            ChatUser2Id = message.ChatUser2Id,
            Content = message.Content,
            SentAt = message.SentAt
        };
    }

    public static Message ToMessage(MessageDto messageDto)
    {
        if (messageDto == null) return null;

        return new Message
        {
            Id = messageDto.Id,
            SenderId = messageDto.SenderId,
            ChatUser1Id = messageDto.ChatUser1Id,
            ChatUser2Id = messageDto.ChatUser2Id,
            Content = messageDto.Content,
            SentAt = messageDto.SentAt
        };
    }
}
}