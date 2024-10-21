using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Dtos;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using  api.Repository;

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

        // Получить подписку по ID
[HttpGet("{id}")]
public async Task<ActionResult<FollowDto>> GetFollowById(int id)
{
    var follow = await _followRepo.GetByIdAsync(id);
    if (follow == null) return NotFound("Follow not found");

    return Ok(FollowMapper.ToFollowDto(follow));
}

        // Создать новую подписку
       [HttpPost]
public async Task<ActionResult<FollowDto>> CreateFollow([FromBody] FollowDto followDto)
{
    var followerExists = await _followRepo.UserExistsAsync(followDto.FollowerId);
    var followeeExists = await _followRepo.UserExistsAsync(followDto.FolloweeId);

    if (!followerExists || !followeeExists)
    {
        return BadRequest("Follower or Followee does not exist.");
    }

    var follow = FollowMapper.ToFollow(followDto);
    var createdFollow = await _followRepo.CreateAsync(follow);

    // Замените GetByIdAsync на GetFollowById
    return CreatedAtAction(nameof(GetFollowById), new { id = createdFollow.Id }, FollowMapper.ToFollowDto(createdFollow));
}

        // Удалить подписку
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var follow = await _followRepo.DeleteAsync(id);
            if (follow == null) return NotFound("Follow not found");

            return Ok("Follow deleted successfully");
        }
    }
}