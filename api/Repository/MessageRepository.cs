using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Dtos;
using api.Models;
using api.Mappers;
using api.Interfaces;

namespace api.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesByChatIdAsync(int user1Id, int user2Id)
        {
            var messages = await _context.Messages
                .Where(m => (m.User1Id == user1Id && m.User2Id == user2Id) ||
                            (m.User1Id == user2Id && m.User2Id == user1Id))
                .ToListAsync();

            return messages.Select(MessageMapper.ToMessageDto);
        }

        public async Task<MessageDto?> GetByIdAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            return MessageMapper.ToMessageDto(message);
        }

        public async Task<MessageDto> CreateAsync(CreateMessageDto createMessageDto)
        {
            var message = MessageMapper.ToMessageModel(createMessageDto);
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return MessageMapper.ToMessageDto(message);
        }

        public async Task<MessageDto?> UpdateAsync(int id, CreateMessageDto updateMessageDto)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            message.Content = updateMessageDto.Content;
            message.SentAt = updateMessageDto.SentAt;
            message.SenderId = updateMessageDto.SenderId;
            message.User1Id = updateMessageDto.User1Id;
            message.User2Id = updateMessageDto.User2Id;

            await _context.SaveChangesAsync();
            return MessageMapper.ToMessageDto(message);
        }

        public async Task<MessageDto?> DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return MessageMapper.ToMessageDto(message);
        }
    }
}