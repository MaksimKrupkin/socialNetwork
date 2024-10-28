using System;
using System.Collections.Generic;
using System.Linq;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class ChatMapper
    {
        // Маппинг из Chat в ChatDto
        public static ChatDto ToChatDto(Chat chat)
        {
            if (chat == null) return null;

            return new ChatDto
            {
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                Messages = chat.Messages.Select(m => ToMessageDto(m)).ToList()
            };
        }

        // Маппинг из CreateChatDto в Chat
        public static Chat ToChatModel(CreateChatDto chatDto)
        {
            if (chatDto == null) return null;

            return new Chat
            {
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select(m => ToMessageModel(m)).ToList()
            };
        }

        // Маппинг из ChatDto (без Id) в Chat
        public static Chat ToChatModel(ChatDto chatDto)
        {
            if (chatDto == null) return null;

            return new Chat
            {
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select(m => ToMessageModel(m)).ToList()
            };
        }

        // Маппинг из Message в MessageDto
        public static MessageDto ToMessageDto(Message message)
        {
            if (message == null) return null;

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
            if (messageDto == null) return null;

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
            if (user == null) return null;

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
            if (userDto == null) return null;

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