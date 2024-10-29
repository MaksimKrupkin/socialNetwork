using System;
using System.Collections.Generic;
using System.Linq;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class ChatMapper
    {
        // Mapping from Chat to ChatDto
        public static ChatDto ToChatDto(Chat chat)
        {
            if (chat == null) return null;

            return new ChatDto
            {
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                Messages = chat.Messages.Select<Message, MessageDto>(ToMessageDto).ToList() // Указание типа Message и MessageDto
            };
        }

        // Mapping from CreateChatDto to Chat
        public static Chat ToChatModel(CreateChatDto chatDto)
        {
            if (chatDto == null) return null;

            return new Chat
            {
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select<MessageDto, Message>(ToMessageModel).ToList() // Указание типа MessageDto и Message
            };
        }

        // Mapping from ChatDto (without Id) to Chat
        public static Chat ToChatModel(ChatDto chatDto)
        {
            if (chatDto == null) return null;

            return new Chat
            {
                User1Id = chatDto.User1Id,
                User2Id = chatDto.User2Id,
                CreatedAt = chatDto.CreatedAt,
                Messages = chatDto.Messages.Select<MessageDto, Message>(ToMessageModel).ToList() // Указание типа MessageDto и Message
            };
        }

        // Mapping from Message to MessageDto (Removed ChatId)
        public static MessageDto ToMessageDto(Message message)
        {
            if (message == null) return null;

            return new MessageDto
            {
                SenderId = message.SenderId,
                Content = message.Content,
                SentAt = message.SentAt
            };
        }

        // Mapping from MessageDto to Message (Removed ChatId)
        public static Message ToMessageModel(MessageDto messageDto)
        {
            if (messageDto == null) return null;

            return new Message
            {
                SenderId = messageDto.SenderId,
                Content = messageDto.Content,
                SentAt = messageDto.SentAt
            };
        }

        // Mapping from User to UserDto
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

        // Mapping from UserDto to User
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