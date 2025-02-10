using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        public int User1Id { get; set; }
        public int User2Id { get; set; }
        
        public Chat Chat { get; set; }
    }
}