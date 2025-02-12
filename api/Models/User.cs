using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class User : IdentityUser<int>  // Используем IdentityUser<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime BirthDay { get; set; }
        
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }

        // Навигационные свойства
        public ICollection<Chat> ChatsAsUser1 { get; set; } = new List<Chat>();
        public ICollection<Chat> ChatsAsUser2 { get; set; } = new List<Chat>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public List<Follow> Followers { get; set; } = new List<Follow>();
        public List<Follow> Following { get; set; } = new List<Follow>();

        public IEnumerable<Chat> AllChats => ChatsAsUser1.Concat(ChatsAsUser2);
    }
}