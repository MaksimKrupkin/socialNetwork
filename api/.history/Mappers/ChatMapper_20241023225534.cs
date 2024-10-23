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
        // Маппинг из Chat в ChatDto (с Id)
        public static ChatDto ToChatDto(Chat chat)
        {
            return new ChatDto
            {
                Id = chat.Id, // Включаем Id
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                Messages = chat.Messages.Select(m => ToMessageDto(m)).ToList()
            };
        }

        // Маппинг из CreateChatDto в Chat (без Id)
        public static Chat ToChatModel(CreateChatDto chatDto)
        {
            return new Chat
            {
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select(m => ToMessageModel(m)).ToList()
            };
        }

        // Маппинг из ChatDto в Chat (с Id, для обновления)
        public static Chat ToChatModel(ChatDto chatDto)
        {
            return new Chat
            {
                Id = chatDto.Id, // Включаем Id
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select(m => ToMessageModel(m)).ToList()
            };
        }

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

        // Маппинг из User в UserDto
        public static UserDto ToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                CreatedAt = user.CreatedAt,
                BirthDay = user.BirthDay
            };
        }

        // Маппинг из UserDto в User
        public static User ToUserModel(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Bio = userDto.Bio,
                ProfileImageUrl = userDto.ProfileImageUrl,
                CreatedAt = userDto.CreatedAt,
                BirthDay = userDto.BirthDay
            };
        }
    }
}