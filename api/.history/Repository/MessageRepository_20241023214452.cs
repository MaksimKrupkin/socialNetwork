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

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _context.Messages
                .Include(m => m.Chat)
                .Include(m => m.Sender)
                .ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages
                .Include(m => m.Chat)
                .Include(m => m.Sender)
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
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            // Обновляем поля сообщения
            message.Content = messageModel.Content;
            message.SentAt = messageModel.SentAt;

            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Message?> DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return message;
        }
    }
}