using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Follow
    {   


        public int FollowerId{get; set;}
        public User Follower{get; set;} //связь многие-ко-многим
        public int FolloweeId{get; set;}
        public User Followee{get; set;}  //связь многие-ко-многим
        public DateTime CreatedAt{get; set;}
    }
}