using System;
using System.Collections.Generic;
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
        public int ChatUser1Id { get; set; } // Ссылка на User1
        public int ChatUser2Id { get; set; } // Ссылка на User2
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        public int ChatId { get; set; } // Добавьте это свойство
        public Chat Chat { get; set; }
        public User Sender { get; set; }
    }
}