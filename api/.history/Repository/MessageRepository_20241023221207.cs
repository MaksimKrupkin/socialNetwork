using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Получить все сообщения в определенном чате
        public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(int chatId)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId)
                .ToListAsync();
        }

        // Получить сообщение по ID
        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        // Создать новое сообщение
        public async Task<Message> CreateAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        // Обновить сообщение
        public async Task<Message?> UpdateAsync(int id, Message messageModel)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            message.Content = messageModel.Content;
            message.SentAt = messageModel.SentAt;

            await _context.SaveChangesAsync();
            return message;
        }

        // Удалить сообщение
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
