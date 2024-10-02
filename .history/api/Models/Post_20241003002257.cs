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
        public User User{get; set;}
        public Comment Comments{get; set;}
        public Like Likes{get; set;}
    }
}