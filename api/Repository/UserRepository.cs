using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.ChatsAsUser1)
                .Include(u => u.ChatsAsUser2)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .Include(u => u.Posts)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.ChatsAsUser1)
                .Include(u => u.ChatsAsUser2)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> UpdateAsync(int id, User userModel)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Email = userModel.Email;
            existingUser.Bio = userModel.Bio;
            existingUser.ProfileImageUrl = userModel.ProfileImageUrl;
            existingUser.BirthDay = userModel.BirthDay;
            existingUser.UserName  = userModel.UserName ; // Убедимся, что Username Name обновляется
            
            if (!string.IsNullOrWhiteSpace(userModel.PasswordHash))
            {
                existingUser.PasswordHash = userModel.PasswordHash;
            }

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
