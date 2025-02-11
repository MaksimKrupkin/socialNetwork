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

        // Получить подписку по составному ключу
        public async Task<Follow?> GetByIdAsync(int followerId, int followeeId)
        {
            return await _context.Follows
                                 .Include(f => f.Follower)
                                 .Include(f => f.Followee)
                                 .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
        }

        // Создать подписку
        public async Task<Follow> CreateAsync(Follow follow)
        {
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
            return await _context.Users.AnyAsync(u => u.Id == userId);
        }
    }
}