using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Bio {get; set;}
        public string ProfileImageUrl {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime BirthDay{get; set;}
        public string PasswordHash{get; set;}
        public ICollection<Post> Posts { get; set; } // связь один-ко-многим
        public ICollection<Follow> Followers{get; set;} // связь один-ко-многим
        public ICollection<Follow> Followings{get; set;} // связь один-ко многим
    }
}