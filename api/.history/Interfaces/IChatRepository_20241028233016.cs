using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatDto>> GetAllAsync();
        Task<ChatDto?> GetByIdAsync(int id);
        Task<ChatDto> CreateAsync(ChatDto CreatechatDto);
        Task<ChatDto?> UpdateAsync(int id, ChatDto updateChatDto);
        Task<ChatDto?> DeleteAsync(int id);
    }
}