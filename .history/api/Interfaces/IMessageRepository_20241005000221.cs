using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int id);
        Task<Message> CreateAsync(Message messageModel);
        Task<Message?> UpdateAsync(int id, Message messageModel);
        Task<Message?> DeleteAsync(int id);
    }
}