using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContent _context;

        public PostRepository(ApplicationDbContext context){
          _context = context;
        }

        // метод для получения всех постов
        public async Task<IEnumerable> GetAllAsync(){
          return await _context.User
          .Include(p => p.Comments)
          .Include(p => p.Likes)
          .ToListAsync();
        }

        // метод для получения поста по ID
        public async Task<Post?> GetByIdAsync(int id){
          return await _context.User
          .Include(p => p.Comments)
          .Include(p => p.Likes)
          .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}