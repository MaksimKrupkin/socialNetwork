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
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context){
          _context = context;
        }

        // метод для получения всех постов
        public async Task<IEnumerable<Post>> GetAllAsync(){
          return await _context.Post
          .Include(p => p.Comments)
          .Include(p => p.Likes)
          .ToListAsync();
        }

        // метод для получения поста по ID
        public async Task<Post?> GetByIdAsync(int id){
          return await _context.Post
          .Include(p => p.Comments)
          .Include(p => p.Likes)
          .FirstOrDefaultAsync(u => u.Id == id);
        }

        // метод для создания поста
        public async Task<Post> CreateAsync(Post postModel){
          await _context.Post.AddAsync(postModel);
          await _context.SaveChangesAsync();
          return postModel;
        }

        // метод для обновления поста
        public async Task<Post?> UpdateAsync(int id, Post postModel){
          var existingPost = await _context.Post.FindAsync(id);
          if (existingPost == null){
            return null;
          }

          existingPost.Image = postModel.Image;
          existingPost.Content = postModel.Content;

          _context.Post.Update(existingPost);
          await _context.SaveChangesAsync();
          return existingPost;
        }

        // метод для удаления поста
        public async Task<Post?> DeleteAsync(int id){
          var post = await _context.Post.FindAsync(id);
          if (post == null){
            return null;
          }

          _context.Post.Remove(post);
          await _context.SaveChanges();
          return post;
        }
    }
}