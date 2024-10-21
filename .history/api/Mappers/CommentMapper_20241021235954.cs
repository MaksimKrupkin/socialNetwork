using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public class CommentMapper
    {
        public static CommentDto ToCommentDto(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                PostId = comment.PostId,
                UserId = comment.UserId,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }

        public static Comment ToComment(CommentDto commentDto)
        {
            return new Comment
            {
                Id = commentDto.Id,
                PostId = commentDto.PostId,
                UserId = commentDto.UserId,
                Content = commentDto.Content,
                CreatedAt = commentDto.CreatedAt
            };
        }
        public static void ToCommentFromUpdateDTO(this UpdateCommentDto updateCommentDto, Comment comment)
        {
            comment.Content = updateCommentDto.Content; 
        }
    }
}