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

        // Foreign keys for the composite key of Chat
        public int ChatUser1Id { get; set; }
        public int ChatUser2Id { get; set; }

        // Navigation property for Chat
        public virtual Chat Chat { get; set; }
    }
}