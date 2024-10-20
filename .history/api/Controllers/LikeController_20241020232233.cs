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
            _likeRepository = likeRepository;
        }

        // Получение всех лайков
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetAllLikes()
        {
            var likes = await _likeRepository.GetAllAsync();
            var likesDto = new List<LikeDto>();
            foreach (var like in likes)
            {
                likesDto.Add(LikeMapper.ToLikeDto(like));
            }
            return Ok(likesDto);
        }

        // Получение лайка по Id
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeDto>> GetLikeById(int id)
        {
            var like = await _likeRepository.GetByIdAsync(id);
            if (like == null) return NotFound("Like not found");
            
            return Ok(LikeMapper.ToLikeDto(like));
        }

        // Создание нового лайка
        [HttpPost]
        public async Task<ActionResult<LikeDto>> CreateLike([FromBody] LikeDto likeDto)
        {
            var like = LikeMapper.ToLike(likeDto);
            var createdLike = await _likeRepository.CreateAsync(like);
            
            return CreatedAtAction(nameof(GetLikeById), new { id = createdLike.Id }, LikeMapper.ToLikeDto(createdLike));
        }

        // Удаление лайка по Id
        [HttpDelete("{id}")]
        public async Task<ActionResult<LikeDto>> DeleteLike(int id)
        {
            var like = await _likeRepository.DeleteAsync(id);
            if (like == null) return NotFound("Like not found");

            return Ok(LikeMapper.ToLikeDto(like));
        }
    }
}