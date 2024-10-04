using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(int id);
        Task<Chat> CreateAsync(Chat chatModel);
        Task<Chat?> UpdateAsync(int id, Chat chatModel);
        Task<Chat?> DeleteAsync(int id);
    }
}