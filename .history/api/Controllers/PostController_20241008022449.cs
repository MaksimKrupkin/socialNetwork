using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Repository;

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
      var postDtos = posts.Select(p => p.ToPostDto());
      return Ok(postDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var post = await _postRepo.GetByIdAsync(id);
      if(post == null) return NotFound();
      return Ok(post.ToPostDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostDto createPostDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var postModel = createPostDto.ToPostFromCreateDTO();
      await _postRepo.CreateAsync(postModel);
      return CreatedAtAction(nameof(GetById), new { id = postModel.Id}, postModel.toPostDto());
    }
  }
}