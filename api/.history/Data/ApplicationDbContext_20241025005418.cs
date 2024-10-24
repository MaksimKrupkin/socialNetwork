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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<User> User {get; set;}
        public DbSet<Post> Post {get; set;}
        public DbSet<Like> Likes {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Follow> Follows {get; set;}
        public DbSet<Chat> Chats {get; set;}
        public DbSet<Message> Messages {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd(); 

           modelBuilder.Entity<Post>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

           modelBuilder.Entity<Like>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
          
           modelBuilder.Entity<Comment>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
          
          
           modelBuilder.Entity<Chat>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
          
           modelBuilder.Entity<Message>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
              // Настройка составного первичного ключа для Follow
    modelBuilder.Entity<Follow>()
        .HasKey(f => new { f.FollowerId, f.FolloweeId });

    modelBuilder.Entity<Follow>()
        .HasOne(f => f.Follower)
        .WithMany(u => u.Following)
        .HasForeignKey(f => f.FollowerId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Follow>()
        .HasOne(f => f.Followee)
        .WithMany(u => u.Followers)
        .HasForeignKey(f => f.FolloweeId)
        .OnDelete(DeleteBehavior.Restrict);

    // Настройка отношений для Chat и User1
    modelBuilder.Entity<Chat>()
        .HasOne(c => c.User1)
        .WithMany(u => u.ChatsAsUser1)
        .HasForeignKey(c => c.User1Id)
        .OnDelete(DeleteBehavior.Restrict);
 

    // Настройка отношений для Chat и User2
    modelBuilder.Entity<Chat>()
        .HasOne(c => c.User2)
        .WithMany(u => u.ChatsAsUser2)
        .HasForeignKey(c => c.User2Id)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Chat>()
        .Property(c => c.Id)
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Message>()
    .Property(m => m.Id)
    .ValueGeneratedOnAdd();
    
        }
    }
}