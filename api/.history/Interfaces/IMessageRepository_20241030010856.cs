using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Interfaces
{
    public interface IMessageRepository
    {
        Task<MessageDto?> GetByIdAsync(int id);
        Task<MessageDto> CreateAsync(CreateMessageDto createMessageDto);
        Task<MessageDto?> UpdateAsync(int id, CreateMessageDto updateMessageDto);
        Task<MessageDto?> DeleteAsync(int id);
    }
}