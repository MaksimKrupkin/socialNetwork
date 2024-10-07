using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Убедитесь, что время в UTC
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; } = string.Empty;

        // Инициализация коллекций
        public ICollection<Chat> ChatsAsUser1 { get; set; } = new List<Chat>(); // Инициализация коллекции
        public ICollection<Chat> ChatsAsUser2 { get; set; } = new List<Chat>(); // Инициализация коллекции

        // Навигационные свойства для объединения всех чатов пользователя
        public IEnumerable<Chat> AllChats => 
            (ChatsAsUser1 ?? new List<Chat>()).Concat(ChatsAsUser2 ?? new List<Chat>());

        public ICollection<Post> Posts { get; set; } = new List<Post>(); // Инициализация коллекции
        public List<Follow> Followers { get; set; } = new List<Follow>(); // Инициализация коллекции
        public List<Follow> Following { get; set; } = new List<Follow>(); // Инициализация коллекции

        // Конструкторинициализирует коллекции, что предотвращает ошибки,
        // связанные с попытками обращения к null коллекциям. Это позволяет избежать ситуаций,
        // когда коллекция может быть null, и гарантирует, что у пользователя всегда есть пустые списки для работы.
        public User()
        {
            ChatsAsUser1 = new List<Chat>();
            ChatsAsUser2 = new List<Chat>();
            Posts = new List<Post>();
            Followers = new List<Follow>();
            Following = new List<Follow>();
        }
    }
}