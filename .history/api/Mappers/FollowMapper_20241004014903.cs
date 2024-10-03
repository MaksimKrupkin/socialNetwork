using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dtos;
using api.Models;

namespace api.Mappers
{
    public class FollowMapper
    {
        public static FollowDto ToFollowDto(Follow follow)
        {
          return new FollowDto
          {
            Id = follow.Id,
            FollowerId = follow.FollowerId,
            FolloweeId = follow.FolloweeId,
            CreatedAt = follow.CreatedAt
          };
        }

        public static Follow ToFollow(FollowDto followDto)
        {
          return new Follow{
            Id = followDto.Id,
            FollowerId = followDto.FollowerId,
            FolloweeId = followDto.FolloweeId,
            CreatedAt = followDto.CreatedAt
          };

        }
    }
}