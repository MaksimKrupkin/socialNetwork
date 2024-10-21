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
    public class CommentRepository: ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
          _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(){
          return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
          return await _context.Comments.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Comment> CreateAsync(Comment commentModel){
          await _context.Comments.AddAsync(commentModel);
          await _context.SaveChangesAsync();
          return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
          var existingComment = await _context.Comments.FindAsync(id);
          if (existingComment == null)
          {
            return null;
          }
          existingComment.Content = commentModel.Content;

          _context.Comments.Update(existingComment);
          await _context.SaveChangesAsync();
          return existingComment;
        }

        public async Task<Comment?> DeleteAsync(int id){
          var comment = await _context.Comments.FindAsync(id);
          if(comment == null) return null;

          _context.Comments.Remove(comment);
          await _context.SaveChangesAsync();
          return comment;
        }

      
    }
}