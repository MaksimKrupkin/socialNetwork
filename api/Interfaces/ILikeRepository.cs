using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetAllAsync();
        Task<Like?> GetByIdAsync(int id);
        Task<Like> CreateAsync(Like likeModel);
        Task<Like?> DeleteAsync(int id);
    }
}