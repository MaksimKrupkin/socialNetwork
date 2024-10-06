using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class CreateUserDto
    {
      public string Email { get; set; }
      public string Bio { get; set; }
      public string ProfileImageUrl { get; set; }
      public DateTime BirthDay { get; set; }
      public string Password { get; set; } 
    }
}