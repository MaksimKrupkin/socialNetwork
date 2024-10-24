using System;
using System.Linq;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class PostMapper
    {
        // Maps Post to PostDto
        public static PostDto ToPostDto(this Post post)
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

        // Maps PostDto to Post
        public static Post ToPost(this PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                UserId = postDto.UserId,
                Image = postDto.Image,
                Content = postDto.Content,
                CreatedAt = postDto.CreatedAt
                // Comments and Likes are managed separately
            };
        }

        // Maps CreatePostDto to Post (for creating new posts)
        public static Post ToPostFromCreateDTO(this CreatePostDto createPostDto, int userId)
        {
            return new Post
            {
                UserId = userId,
                Image = createPostDto.Image,
                Content = createPostDto.Content,
                CreatedAt = DateTime.UtcNow
            };
        }

        // Maps UpdatePostDto to Post (for updating existing posts)
        public static void ToPostFromUpdateDTO(this UpdatePostDto updatePostDto, Post post)
        {
            post.Image = updatePostDto.Image;
            post.Content = updatePostDto.Content;
            
        }

        // Maps Post to PostWithDetailsDto (for detailed post info including user, comments, and likes)
        public static PostWithDetailtsDto ToPostWithDetailsDto(this Post post)
        {
            return new PostWithDetailtsDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Image = post.Image,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                User = post.User, // Assuming navigation property is loaded
                Comments = post.Comments?.Select(CommentMapper.ToCommentDto).ToList() ?? new List<CommentDto>(), // Преобразование комментариев
                Likes = post.Likes?.Select(LikeMapper.ToLikeDto).ToList() ?? new List<LikeDto>() // Преобразование лайков
            };
        }
    }
}
