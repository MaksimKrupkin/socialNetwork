using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Dtos;
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

        public async Task<IEnumerable<MessageDto>> GetMessagesByChatIdAsync(int chatId)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    ChatId = m.ChatId,
                    Content = m.Content,
                    SentAt = m.SentAt
                })
                .ToListAsync();
        }

        public async Task<MessageDto?> GetByIdAsync(int id)
        {
            var message = await _context.Messages
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<MessageDto> CreateAsync(CreateMessageDto messageDto)
        {
            var message = new Message
            {
                SenderId = messageDto.SenderId,
                Content = messageDto.Content,
                SentAt = messageDto.SentAt
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ChatId = message.ChatId,
                Content = message.Content,
                SentAt = message.SentAt
            };
        }

        public async Task<MessageDto?> UpdateAsync(int id, CreateMessageDto updateMessageDto)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            message.Content = updateMessageDto.Content;
            message.SentAt = updateMessageDto.SentAt;

            await _context.SaveChangesAsync();

            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ChatId = message.ChatId,
                Content = message.Content,
                SentAt = message.SentAt
            };
        }

        public async Task<MessageDto?> DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ChatId = message.ChatId,
                Content = message.Content,
                SentAt = message.SentAt
            };
        }
    }
}