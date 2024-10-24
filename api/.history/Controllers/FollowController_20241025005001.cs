using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Dtos;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/follows")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowRepository _followRepo;

        public FollowController(IFollowRepository followRepository)
        {
            _followRepo = followRepository;
        }

        // Получить все подписки
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowDto>>> GetAllFollows()
        {
            var follows = await _followRepo.GetAllAsync();
            var followsDto = follows.Select(FollowMapper.ToFollowDto).ToList();
            return Ok(followsDto);
        }

        // Получить подписку по составному ключу
        [HttpGet("{followerId}/{followeeId}")]
        public async Task<ActionResult<FollowDto>> GetFollowById(int followerId, int followeeId)
        {
            var follow = await _followRepo.GetByIdAsync(followerId, followeeId);
            if (follow == null) return NotFound("Follow not found");

            return Ok(FollowMapper.ToFollowDto(follow));
        }

        // Создать новую подписку
        [HttpPost]
        public async Task<ActionResult<FollowDto>> CreateFollow([FromBody] CreateFollowDto createFollowDto)
        {
            var followerExists = await _followRepo.UserExistsAsync(createFollowDto.FollowerId);
            var followeeExists = await _followRepo.UserExistsAsync(createFollowDto.FolloweeId);

            if (!followerExists || !followeeExists)
            {
                return BadRequest("Follower or Followee does not exist.");
            }

            var follow = FollowMapper.ToFollow(createFollowDto);
            var createdFollow = await _followRepo.CreateAsync(follow);

            return CreatedAtAction(nameof(GetFollowById), new { followerId = createdFollow.FollowerId, followeeId = createdFollow.FolloweeId }, FollowMapper.ToFollowDto(createdFollow));
        }

        // Удалить подписку
        [HttpDelete("{followerId}/{followeeId}")]
        public async Task<IActionResult> Delete(int followerId, int followeeId)
        {
            var follow = await _followRepo.DeleteAsync(followerId, followeeId);
            if (follow == null) return NotFound("Follow not found");

            return Ok("Follow deleted successfully");
        }
    }
}