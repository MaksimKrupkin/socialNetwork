
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

        public async Task<IEnumerable<MessageDto>> GetMessagesByChatIdAsync(int chatUser1Id, int chatUser2Id)
        {
            var messages = await _context.Messages
                .Where(m => m.ChatId == chatUser1Id || m.ChatId == chatUser2Id)
                .ToListAsync();

            return messages.Select(MessageMapper.ToMessageDto)
                           .Where(dto => dto != null)!; // Null-safe filtering
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
            return MessageMapper.ToMessageDto(message)!;
        }

        public async Task<MessageDto?> UpdateAsync(int id, CreateMessageDto updateMessageDto)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;

            message.Content = updateMessageDto.Content;
            message.SentAt = updateMessageDto.SentAt;
            message.SenderId = updateMessageDto.SenderId;
            message.ChatId = updateMessageDto.User1Id; // Assuming ChatId maps to User1Id

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
