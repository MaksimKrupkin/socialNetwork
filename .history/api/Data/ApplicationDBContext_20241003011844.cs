using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){}

        public DbSet<User> User {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<Like> Like {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Follow> Follows {get; set;}
        public DbSet<Chat> Chats {get; set;}
        public DbSet<Message> Messages {get; set;}
    }
}