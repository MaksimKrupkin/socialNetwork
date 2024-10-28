using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(int chatId)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId)
                .Include(m => m.Sender)
                .ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Chat)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Message> CreateAsync(Message messageModel)
        {
            _context.Messages.Add(messageModel);
            await _context.SaveChangesAsync();
            return messageModel;
        }

        public async Task<Message?> UpdateAsync(int id, Message messageModel)
        {
            var existingMessage = await _context.Messages.FindAsync(id);
            if (existingMessage == null)
            {
                return null;
            }

            existingMessage.Content = messageModel.Content;
            existingMessage.SentAt = messageModel.SentAt;

            await _context.SaveChangesAsync();
            return existingMessage;
        }

        public async Task<Message?> DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return null;
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return message;
        }
    }
}