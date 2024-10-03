using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UpdateUserDto
    {
      public string Email { get; set; }
      public string Bio { get; set; }
      public string ProfileImageUrl { get; set; }
      public DateTime BirthDay { get; set; }
      // Возможно, вы захотите добавить поле для смены пароля, если нужно
      public string Password { get; set; } // Это можно сделать опциональным
    }
}