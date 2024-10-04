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

        // Конструктор с внедрением зависимости контекста базы данных
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения всех пользователей
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.ChatsAsUser1)
                .Include(u => u.ChatsAsUser2)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .ToListAsync();
        }

        // Метод для получения пользователя по ID
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.ChatsAsUser1)
                .Include(u => u.ChatsAsUser2)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        // Метод для создания нового пользователя
        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync(); // Сохранение изменений в базе данных
            return userModel;
        }

        // Метод для обновления существующего пользователя
        public async Task<User?> UpdateAsync(int id, User userModel)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            // Обновляем существующего пользователя
            existingUser.Email = userModel.Email;
            existingUser.Bio = userModel.Bio;
            existingUser.ProfileImageUrl = userModel.ProfileImageUrl;
            existingUser.BirthDay = userModel.BirthDay;
            if (!string.IsNullOrWhiteSpace(userModel.PasswordHash))
            {
                existingUser.PasswordHash = userModel.PasswordHash; // Хешированный пароль
            }

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync(); // Сохранение изменений
            return existingUser;
        }

        // Метод для удаления пользователя
        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(); // Сохранение изменений
            return user;
        }
    }
}