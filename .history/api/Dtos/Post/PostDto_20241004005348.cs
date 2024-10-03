using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class PostDto
    {
      public int Id {get; set;}
      public int UserId {get; set;}
      public string Image {get; set;}
      public string Content {get; set;}
      public DateTime CreatedAt {get; set;}
      public List<CommentDto> Comments {get; set;} // Маппинг для комментариев
      public List<LikeDto> Likes {get; set;} // Маппинг для лайков
    }
}