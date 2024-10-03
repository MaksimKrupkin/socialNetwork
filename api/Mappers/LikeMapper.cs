using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public class LikeMapper
    {
        public static LikeDto ToLikeDto(Like like)
        {
            return new LikeDto
            {
                Id = like.Id,
                PostId = like.PostId,
                UserId = like.UserId,
                CreatedAt = like.CreatedAt
            };
        }

        public static Like ToLike(LikeDto likeDto)
        {
            return new Like
            {
                Id = likeDto.Id,
                PostId = likeDto.PostId,
                UserId = likeDto.UserId,
                CreatedAt = likeDto.CreatedAt
            };
        }
    }
}