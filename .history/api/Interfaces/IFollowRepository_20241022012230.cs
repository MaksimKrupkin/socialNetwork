using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
public interface IFollowRepository
{
    Task<IEnumerable<Follow>> GetAllAsync();
    Task<Follow?> GetByIdAsync(int id);
    Task<Follow> CreateAsync(Follow follow);
    Task<Follow?> DeleteAsync(int followerId, int followeeId); // Измените здесь
    Task<bool> UserExistsAsync(int userId);
}
}