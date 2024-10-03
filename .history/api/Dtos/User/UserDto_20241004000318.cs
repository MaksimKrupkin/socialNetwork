using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Bio {get; set;}
        public string ProfileImageUrl {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime BirthDay {get; set;}

        // Этот DTO можно использовать для передачи общей информации о пользователе
        // без передачи пароля и связанных коллекций (чаты, посты и подписчики).
    }
}