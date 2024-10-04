using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);
        Task<Post> CreateAsync(Post postModel);
        Task<Post?> UpdateAsync(int id, Post postModel);
        Task<Post?> DeleteAsync(int id); 
    }
}