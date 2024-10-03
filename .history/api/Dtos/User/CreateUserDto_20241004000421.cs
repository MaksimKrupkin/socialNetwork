using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class CreateUserDto
    {
      public string Email { get; set; }
      public string Bio { get; set; }
      public string ProfileImageUrl { get; set; }
      public DateTime BirthDay { get; set; }
      public string Password { get; set; } // Используем для ввода пароля
    }
}