using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class FollowMapper
    {
        public static Follow ToFollow(CreateFollowDto createFollowDto)
        {
            return new Follow
            {
                FollowerId = createFollowDto.FollowerId,
                FolloweeId = createFollowDto.FolloweeId,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static FollowDto ToFollowDto(Follow follow)
        {
            return new FollowDto
            {
                FollowerId = follow.FollowerId,
                FolloweeId = follow.FolloweeId,
                CreatedAt = follow.CreatedAt
            };
        }
    }
}