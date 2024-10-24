using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Chat

    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id{get; set;}

        public int User1Id{get; set;}
        public User User1{get; set;}
        public int User2Id{get; set;}
        public User User2{get; set;}
        public DateTime CreatedAt{get; set;}
        public ICollection<Message> Messages{get; set;} // связь один-ко-многим
    }
}