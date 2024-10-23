using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var chats = await _chatRepository.GetAllAsync();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetById(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null) return NotFound();
            return Ok(chat);
        }

        [HttpPost]
        public async Task<ActionResult<Chat>> Create(Chat chatModel)
        {
            var createdChat = await _chatRepository.CreateAsync(chatModel);
            return CreatedAtAction(nameof(GetById), new { id = createdChat.Id }, createdChat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Chat>> Update(int id, Chat chatModel)
        {
            var updatedChat = await _chatRepository.UpdateAsync(id, chatModel);
            if (updatedChat == null) return NotFound();
            return Ok(updatedChat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Chat>> Delete(int id)
        {
            var deletedChat = await _chatRepository.DeleteAsync(id);
            if (deletedChat == null) return NotFound();
            return Ok(deletedChat);
        }
    }
}
