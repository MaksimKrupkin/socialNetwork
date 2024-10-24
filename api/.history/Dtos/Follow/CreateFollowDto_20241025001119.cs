using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateFollowDto
    {    
        public int FollowerId{get; set;}
        public int FolloweeId{get; set;}
        public DateTime CreatedAt{get; set;}
    }
}