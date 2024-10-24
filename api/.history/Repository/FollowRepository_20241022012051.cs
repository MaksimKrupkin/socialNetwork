using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Получить все подписки
        public async Task<IEnumerable<Follow>> GetAllAsync()
        {
            return await _context.Follows
                                 .Include(f => f.Follower)
                                 .Include(f => f.Followee)
                                 .ToListAsync();
        }

        // Получить подписку по ID
        public async Task<Follow?> GetByIdAsync(int id)
        {
            return await _context.Follows
                                 .Include(f => f.Follower)
                                 .Include(f => f.Followee)
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        // Создать подписку
        public async Task<Follow> CreateAsync(Follow follow)
        {
            // Проверка существования подписчика и подписанного
            var followerExists = await _context.User.AnyAsync(u => u.Id == follow.FollowerId);
            var followeeExists = await _context.User.AnyAsync(u => u.Id == follow.FolloweeId);

            if (!followerExists || !followeeExists)
            {
                throw new InvalidOperationException("Follower or Followee does not exist.");
            }

            await _context.Follows.AddAsync(follow);
            await _context.SaveChangesAsync();
            return follow;
        }

        // Удалить подписку
public async Task<Follow?> DeleteAsync(int followerId, int followeeId)
{
    var follow = await _context.Follows
        .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FolloweeId == followeeId);

    if (follow == null) return null;

    _context.Follows.Remove(follow);
    await _context.SaveChangesAsync();
    return follow;
}

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _context.User.AnyAsync(u => u.Id == userId);
        }
    }
}