using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<MessageDto>> GetMessagesByChatIdAsync(int chatUser1Id, int chatUser2Id);
        Task<MessageDto?> GetByIdAsync(int id);
        Task<MessageDto> CreateAsync(CreateMessageDto createMessageDto);
        Task<MessageDto?> UpdateAsync(int id, CreateMessageDto updateMessageDto);
        Task<MessageDto?> DeleteAsync(int id);
    }
}