using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class CommentDto
    {
      public int Id { get; set; }
      public int PostId { get; set; }
      public int UserId { get; set; }
      public string Content { get; set; }
      public DateTime CreatedAt { get; set; }
    }
}