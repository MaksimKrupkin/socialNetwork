using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;

        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatDto>>> GetAllChats()
        {
            var chats = await _chatRepository.GetAllAsync();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDto>> GetChatById(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null) return NotFound();
            return Ok(chat);
        }

        [HttpPost]
        public async Task<ActionResult<ChatDto>> CreateChat(CreateChatDto createChatDto)
        {
            var chat = await _chatRepository.CreateAsync(createChatDto);
            return CreatedAtAction(nameof(GetChatById), new { id = chat.Id }, chat);
        }
    }
}
