using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class ChatMapper
    {
        public static ChatDto ToChatDto(Chat chat)
        {
            if (chat == null) return null;

            return new ChatDto
            {
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                Messages = chat.Messages.Select(MessageMapper.ToMessageDto).ToList()
            };
        }

        public static Chat ToChat(ChatDto chatDto)
        {
            if (chatDto == null) return null;

            return new Chat
            {
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt
            };
        }
    }
}