using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
public class CreateCommentDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
}
}