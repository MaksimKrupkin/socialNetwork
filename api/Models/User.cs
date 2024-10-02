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
        public ICollection<Chat> ChatsAsUser1 { get; set; }
        // Навигационные свойства для чатов, где пользователь является User2
        public ICollection<Chat> ChatsAsUser2 { get; set; }
        // (Опционально) Свойство для объединения всех чатов пользователя
        public IEnumerable<Chat> AllChats => 
            (ChatsAsUser1 ?? new List<Chat>()).Concat(ChatsAsUser2 ?? new List<Chat>());
        public ICollection<Post> Posts { get; set; } // связь один-ко-многим
        public List<Follow> Followers { get; set; } = new List<Follow>(); // связь один-ко-многим
        public List<Follow> Following { get; set; } = new List<Follow>(); // связь один-ко-многим
    }
}