using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Dtos;
using api.Models;
using api.Mappers;
using System;
using api.Interfaces;

namespace api.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatDto>> GetAllAsync()
        {
            var chats = await _context.Chats
                .Include(c => c.Messages)
                .ToListAsync();

            return chats.Select(ChatMapper.ToChatDto);
        }

        public async Task<ChatDto?> GetByIdAsync(int user1Id, int user2Id)
        {
            var chat = await _context.Chats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => (c.User1Id == user1Id && c.User2Id == user2Id) ||
                                            (c.User1Id == user2Id && c.User2Id == user1Id));

            return ChatMapper.ToChatDto(chat);
        }

        public async Task<ChatDto> CreateAsync(CreateChatDto createChatDto)
        {
            var chat = ChatMapper.ToChatModel(createChatDto);
            chat.CreatedAt = DateTime.UtcNow; // Установка даты создания

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return ChatMapper.ToChatDto(chat);
        }

        public async Task<ChatDto?> UpdateAsync(int user1Id, int user2Id, CreateChatDto updateChatDto)
        {
            var chat = await _context.Chats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.User1Id == user1Id && c.User2Id == user2Id ||
                                          c.User1Id == user2Id && c.User2Id == user1Id);
            if (chat == null) return null;

            // Update chat properties
            chat.User1Id = updateChatDto.User1Id;
            chat.User2Id = updateChatDto.User2Id;
            chat.CreatedAt = updateChatDto.CreatedAt;
            chat.Messages = updateChatDto.Messages.Select(ChatMapper.ToMessageModel).ToList();

            await _context.SaveChangesAsync();
            return ChatMapper.ToChatDto(chat);
        }

public async Task<ChatDto?> DeleteAsync(int user1Id, int user2Id)
{
    var chat = await _context.Chats
        .FirstOrDefaultAsync(c => (c.User1Id == user1Id && c.User2Id == user2Id) ||
                                  (c.User1Id == user2Id && c.User2Id == user1Id));
    if (chat == null) return null;

    _context.Chats.Remove(chat);
    await _context.SaveChangesAsync();
    return ChatMapper.ToChatDto(chat);
}
    }
}