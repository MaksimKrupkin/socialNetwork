using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces;
using api.Dtos;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/like")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentsRepository commentRepository)
        {
          _commentRepo = commentRepository;
        }

        // Получение всех комментариев
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllComments()
        {
          if (!ModelState.IsValid) return BadRequest(ModelState);

          var comments = await _commentRepo.GetAllAsync();
          var commentsDto = comments.Select(CommentMapper.ToCommentDto).ToList();

          return Ok(commentsDto);
        }

        // Получение комментария по id
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
          var comment = await _commentRepo.GetByIdAsync(id);
          if (comment == null) return NotFound("Comment not found");

          return Ok(CommentMapper.ToCommentDto(comment));
        }

        //создание нового лайка
        [HttpPost]
        public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CommentDto commentDto)
        {
          var comment = CommentMapper.ToComment(commentDto);
          var createdComment = await _commentRepo.CreateAsync(comment);

          return CreatedAtAction(nameof(GetCommentById), new {id = createdComment.Id}, CommentMapper.ToCommentDto(createdComment));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
          if(!ModelState.IsValid) return BadRequest(ModelState);
          var commentModel = await _commentRepo.GetByIdAsync(id);
          if(commentModel == null)
          {
            return NotFound();
          }
          updateDto.ToCommentFromUpdateDTO(commentModel); 
          await _commentRepo.UpdateAsync(id, commentModel);
          return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
          if (!ModelState.IsValid) return BadRequest(ModelState);
          var commentModel = await _commentRepo.DeleteAsync(id);
          if(commentModel == null) return NotFound();
          return NotFound("CommentNotFound");

          
        }
    }
}