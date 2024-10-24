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
    public class LikesController : ControllerBase
    {
        private readonly ILikeRepository _likeRepo;

        public LikesController(ILikeRepository likeRepository)
        {
            _likeRepo = likeRepository;
        }

        // Получение всех лайков
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetAllLikes()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
    
            var likes = await _likeRepo.GetAllAsync();
            var likesDto = likes.Select(LikeMapper.ToLikeDto).ToList();

            return Ok(likesDto);
        }

        // Получение лайка по Id
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeDto>> GetLikeById(int id)
        {
            var like = await _likeRepo.GetByIdAsync(id);
            if (like == null) return NotFound("Like not found");
            
            return Ok(LikeMapper.ToLikeDto(like));
        }

        // Создание нового лайка
[HttpPost]
public async Task<ActionResult<LikeDto>> CreateLike([FromBody] CreateLikeDto createLikeDto)
{
    var like = new Like
    {
        PostId = createLikeDto.PostId,
        UserId = createLikeDto.UserId,
        CreatedAt = DateTime.UtcNow // Устанавливаем текущее время
    };

    var createdLike = await _likeRepo.CreateAsync(like);
    
    return CreatedAtAction(nameof(GetLikeById), new { id = createdLike.Id }, LikeMapper.ToLikeDto(createdLike));
}

        // Удаление лайка по Id
        [HttpDelete("{id}")]
        public async Task<ActionResult<LikeDto>> DeleteLike(int id)
        {
            var like = await _likeRepo.DeleteAsync(id);
            if (like == null) return NotFound("Like not found");

            return Ok(LikeMapper.ToLikeDto(like));
        }
    }
}