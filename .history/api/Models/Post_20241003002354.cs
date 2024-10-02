using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Post
    {
        public int id{get; set;}
        public int UserId{get; set;}
        public string image{get; set}
        public string Content{get; set;}
        public DateTime CreatedAt{get; set;}
        public ICollection<User> User{get; set;}
        public ICollection<Comment> Comments{get; set;}
        public ICollection<Like> Likes{get; set;}
    }
}