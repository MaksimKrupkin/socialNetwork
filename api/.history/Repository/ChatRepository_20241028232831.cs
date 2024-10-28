using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Dtos;
using api.Models;
using api.Mappers;
using System;

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

        public async Task<ChatDto?> GetByIdAsync(int id)
        {
            var chat = await _context.Chats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.User1Id == id || c.User2Id == id); // Пример поиска по составному ключу

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

        public async Task<ChatDto?> UpdateAsync(int id, CreateChatDto updateChatDto)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null) return null;

            // Обновление свойств чата
            chat.User1Id = updateChatDto.User1Id;
            chat.User2Id = updateChatDto.User2Id;
            chat.CreatedAt = updateChatDto.CreatedAt;
            chat.Messages = updateChatDto.Messages.Select(m => ChatMapper.ToMessageModel(m)).ToList();

            await _context.SaveChangesAsync();
            return ChatMapper.ToChatDto(chat);
        }

        public async Task<ChatDto?> DeleteAsync(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null) return null;

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return ChatMapper.ToChatDto(chat);
        }
    }
}