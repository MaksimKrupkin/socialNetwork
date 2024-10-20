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
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;
        public LikeRepository(ApplicationDbContext context){
          _context = context;
        }

        public async Task<IEnumerable<Like>> GetAllAsync(){
          return await _context.Likes
          .ToListAsync();
        }

        public async Task<Like?> GetByIdAsync(int id){
          return await _context.Likes.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Like> CreateAsync (Like likeModel){
          await _context.Likes.AddAsync(likeModel);
          await _context.SaveChangesAsync();
          return likeModel;
        } 

        public async Task<Like?> DeleteAsync (int id){
          var like = await _context.Likes.FindAsync(id);
          if (like == null) return null;
          _context.Likes.Remove(like);
          await _context.SaveChangesAsync();
          return like;
        }
    }
}