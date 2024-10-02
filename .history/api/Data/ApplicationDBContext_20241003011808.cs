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
        public DbSet<Post> Post {get; set;}
        public DbSet<Like> Like {get; set;}
        public DbSet<Comment> Comment {get; set;}
        public DbSet<Follow> Follow {get; set;}
        public DbSet<Chat> Chat {get; set;}
        public DbSet<Message> Message {get; set;}
    }
}