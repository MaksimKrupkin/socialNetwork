using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _postRepo;

        public PostController(ApplicationDbContext context, IPostRepository postRepo)
        {
            _context = context;
            _postRepo = postRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var posts = await _postRepo.GetAllAsync();
            var postDtos = posts.Select(p => PostMapper.ToPostDto(p));
            return Ok(postDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var post = await _postRepo.GetByIdAsync(id);
            if(post == null) return NotFound();
            return Ok(PostMapper.ToPostDto(post));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDto createPostDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = 1; // This would be fetched from the authenticated user
            var postModel = PostMapper.ToPost(createPostDto, userId);
            await _postRepo.CreateAsync(postModel);
            return CreatedAtAction(nameof(GetById), new { id = postModel.Id}, PostMapper.ToPostDto(postModel));
        }
    }
}