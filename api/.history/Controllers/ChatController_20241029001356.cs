using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<ChatDto>>> GetAll()
        {
            var chats = await _chatRepository.GetAllAsync();
            return Ok(chats);
        }

        [HttpGet("{user1Id}/{user2Id}")]
        public async Task<ActionResult<ChatDto>> GetById(int user1Id, int user2Id)
        {
            var chat = await _chatRepository.GetByIdAsync(user1Id, user2Id);
            if (chat == null) return NotFound();

            return Ok(chat);
        }

        [HttpPost]
        public async Task<ActionResult<ChatDto>> Create(CreateChatDto createChatDto)
        {
            var chat = await _chatRepository.CreateAsync(createChatDto);
            return CreatedAtAction(nameof(GetById), new { id = chat.User1Id }, chat); // Вернуть 201 и созданный чат
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChatDto>> Update(int id, CreateChatDto updateChatDto)
        {
            var chat = await _chatRepository.UpdateAsync(id, updateChatDto);
            if (chat == null) return NotFound();

            return Ok(chat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var chat = await _chatRepository.DeleteAsync(id);
            if (chat == null) return NotFound();

            return NoContent(); // Вернуть 204 при успешном удалении
        }
    }
}
