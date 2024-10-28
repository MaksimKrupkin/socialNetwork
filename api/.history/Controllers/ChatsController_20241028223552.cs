using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;

        public ChatsController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetAll()
        {
            return Ok(await _chatRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetById(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null) return NotFound();
            return Ok(chat);
        }

        [HttpPost]
        public async Task<ActionResult<Chat>> Create(Chat chat)
        {
            var newChat = await _chatRepository.CreateAsync(chat);
            return CreatedAtAction(nameof(GetById), new { id = newChat.Id }, newChat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Chat chat)
        {
            var updatedChat = await _chatRepository.UpdateAsync(id, chat);
            if (updatedChat == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedChat = await _chatRepository.DeleteAsync(id);
            if (deletedChat == null) return NotFound();
            return NoContent();
        }
    }
}
