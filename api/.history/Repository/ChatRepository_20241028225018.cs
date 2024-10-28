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
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatDto>> GetAllAsync()
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .Select(c => new ChatDto
                {
                    Id = c.Id,
                    User1Id = c.User1Id,
                    User2Id = c.User2Id,
                    CreatedAt = c.CreatedAt,
                    Messages = c.Messages.Select(m => new MessageDto
                    {
                        Id = m.Id,
                        SenderId = m.SenderId,
                        ChatId = m.ChatId,
                        Content = m.Content,
                        SentAt = m.SentAt
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<ChatDto?> GetByIdAsync(int id)
        {
            var chat = await _context.Chats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chat == null) return null;

            return new ChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                Messages = chat.Messages.Select(m => new MessageDto
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    ChatId = m.ChatId,
                    Content = m.Content,
                    SentAt = m.SentAt
                }).ToList()
            };
        }

        public async Task<ChatDto> CreateAsync(CreateChatDto createChatDto)
        {
            var chat = new Chat
            {
                User1Id = createChatDto.User1Id,
                User2Id = createChatDto.User2Id,
                CreatedAt = createChatDto.CreatedAt
            };

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return new ChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt
            };
        }
    }
}
