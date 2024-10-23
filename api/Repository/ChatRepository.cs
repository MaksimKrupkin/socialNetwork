using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chat>> GetAllAsync()
        {
            return await _context.Chats
                .Include(c => c.Messages) // Включаем сообщения
                .Include(c => c.User1)    // Включаем первого пользователя
                .Include(c => c.User2)    // Включаем второго пользователя
                .ToListAsync();
        }

        public async Task<Chat?> GetByIdAsync(int id)
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .Include(c => c.User1)
                .Include(c => c.User2)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Chat> CreateAsync(Chat chatModel)
        {
            _context.Chats.Add(chatModel);
            await _context.SaveChangesAsync();
            return chatModel;
        }

        public async Task<Chat?> UpdateAsync(int id, Chat chatModel)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null) return null;

            // Обновляем поля чата (если необходимо)
            chat.User1Id = chatModel.User1Id;
            chat.User2Id = chatModel.User2Id;
            chat.CreatedAt = chatModel.CreatedAt;

            await _context.SaveChangesAsync();
            return chat;
        }

        public async Task<Chat?> DeleteAsync(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null) return null;

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return chat;
        }
    }
}