using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Comment
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id{get; set;}

        public int PostId{get; set;}
        public int UserId{get; set;}
        public Post Post{get; set;}
        public User User{get; set;}
        public string Content{get; set;}
        public DateTime CreatedAt{get; set;}
    }
}