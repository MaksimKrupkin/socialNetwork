using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatDto>> GetAllAsync();
        Task<ChatDto?> GetByIdAsync(int user1Id, int user2Id);
        Task<ChatDto> CreateAsync(CreateChatDto createChatDto);
        Task<ChatDto?> UpdateAsync(int user1Id, int user2Id, CreateChatDto updateChatDto);
        Task<ChatDto?> DeleteAsync(int user1Id, int user2Id);
    }
}