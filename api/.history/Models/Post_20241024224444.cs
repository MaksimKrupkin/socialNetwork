using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id{get; set;}
        
        public int UserId{get; set;}
        public string Image{get; set;}
        public string Content{get; set;}
        public DateTime CreatedAt{get; set;}
        public User User{get; set;}
        public ICollection<Comment> Comments{get; set;} // связь один-ко-многим
        public ICollection<Like> Likes{get; set;} // связь один-ко-многим
    }
}