using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;


namespace api.Dtos
{
    public class PostWithDetailtsDto
    {
      public int Id { get; set; }
      public int UserId { get; set; }
      public string Image { get; set; }
      public string Content { get; set; }
      public DateTime CreatedAt { get; set; }
      public User User { get; set; }
      public ICollection<CommentDto> Comments { get; set; } // Измените на CommentDto
      public ICollection<LikeDto> Likes { get; set; }
    }
}