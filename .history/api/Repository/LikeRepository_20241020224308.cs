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
          return await _context.Like
          .ToListAsync();
        }

        public async Task<Like?> GetById(){
          return await _context.Like.FirstOrDefaultAsync();
        }
    }
}