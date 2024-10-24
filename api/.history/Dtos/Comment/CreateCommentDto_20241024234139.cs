using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Like
{
    public class CreateLikeDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}