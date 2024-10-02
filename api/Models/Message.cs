using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Message
    {
        public int Id{get; set;}
        public int SenderId{get; set;}
        public User Sender{get; set;}
        public int ChatId{get; set;}
        public Chat Chat{get; set;}
        public string Content{get; set;}
        public DateTime SentAt{get; set;}
    }
}