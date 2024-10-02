using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int id {get; set;}
        public string Email {get; set;}
        public string Bio {get; set;}
        public string ProfileImageUrl {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime BirthDay{get; set;}
        public string PasswordHash{get; set;}
        public ICollection<Post>Posts{get; set;}
        public ICollection<Follow>Followers{get; set;}
        public ICollection<Follow>Followings{get; set;}
    }
}