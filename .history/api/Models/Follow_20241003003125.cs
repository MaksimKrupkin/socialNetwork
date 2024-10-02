using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Follow
    {
        public int Id{get; set;}
        public int FollowerId{get; set;}
        public Follower Follower{get; set;}
        public int FolloweeId{get; set;}
        public Followee Followee{get; set;}
        public DateTime CreatedAt{get; set;}
    }
}