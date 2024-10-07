using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;


namespace api.Dtos.Post
{
    public class CreatePostDto
    {
      public string Image {get; set;}
      public string Content {get; set;}
    }
}