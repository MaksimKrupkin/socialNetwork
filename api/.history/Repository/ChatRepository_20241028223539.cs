using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
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
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Include(c => c.Messages)
                .ToListAsync();
        }

        public async Task<Chat?> GetByIdAsync(int id)
        {
            return await _context.Chats
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Include(c => c.Messages)
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
            var existingChat = await _context.Chats.FindAsync(id);
            if (existingChat == null)
            {
                return null;
            }

            existingChat.User1Id = chatModel.User1Id;
            existingChat.User2Id = chatModel.User2Id;

            await _context.SaveChangesAsync();
            return existingChat;
        }

        public async Task<Chat?> DeleteAsync(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return null;
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return chat;
        }
    }
}