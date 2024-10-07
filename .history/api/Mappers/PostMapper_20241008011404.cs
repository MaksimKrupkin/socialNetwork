using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;


namespace api.Mappers
{
    public class PostMapper
    {
        public static PostDto ToPostDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Image = post.Image,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Comments = post.Comments?.Select(CommentMapper.ToCommentDto).ToList(),
                Likes = post.Likes?.Select(LikeMapper.ToLikeDto).ToList()
            };
        }

        public static Post ToPost(PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                UserId = postDto.UserId,
                Image = postDto.Image,
                Content = postDto.Content,
                CreatedAt = postDto.CreatedAt
                // Комментарии и лайки обычно управляются отдельно
            };
        }
    }
}