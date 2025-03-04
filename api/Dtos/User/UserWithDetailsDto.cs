using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class UserWithDetailsDto
    {
      public int Id { get; set; }
      public string Email { get; set; }
      public string Bio { get; set; }
      public string ProfileImageUrl { get; set; }
      
      public string UserName  { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime BirthDay { get; set; }
      // Для передачи чатов
      public List<ChatDto> Chats { get; set; }
      // Для передачи постов
      public List<PostDto> Posts { get; set; }
      // Для передачи подписчиков и подписок
      public List<UserDto> Followers { get; set; }
      public List<UserDto> Following { get; set; }

      //Расширенный DTO с чатов и постами
    }
}