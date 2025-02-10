using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автоматическая генерация Id
        public int Id { get; set; }
        
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Убедитесь, что время в UTC
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        
        public string NickName { get; set; } = string.Empty;

        public ICollection<Chat> ChatsAsUser1 { get; set; } = new List<Chat>();
        public ICollection<Chat> ChatsAsUser2 { get; set; } = new List<Chat>();

        public IEnumerable<Chat> AllChats => 
            (ChatsAsUser1 ?? new List<Chat>()).Concat(ChatsAsUser2 ?? new List<Chat>());

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public List<Follow> Followers { get; set; } = new List<Follow>();
        public List<Follow> Following { get; set; } = new List<Follow>();

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
