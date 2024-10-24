using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public int ChatId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }  // Добавляем это свойство
        public Chat Chat { get; set; }
        public User Sender { get; set; }
    }
}