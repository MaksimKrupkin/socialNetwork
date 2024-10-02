using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){}

        public DbSet<User> User {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<Like> Like {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Follow> Follows {get; set;}
        public DbSet<Chat> Chats {get; set;}
        public DbSet<Message> Messages {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Дополнительные настройки отношений и ключей

            // Настройка составного первичного ключа для Follow
            modelBuilder.Entity<Follow>()
                .HasKey(f => new { f.FollowerId, f.FolloweeId });

            // Настройка связей для Chat и User1
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User1)
                .WithMany(u => u.ChatsAsUser1)
                .HasForeignKey(c => c.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Настройка связей для Chat и User2
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User2)
                .WithMany(u => u.ChatsAsUser2)
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Остальные настройки...
        }
    }
}