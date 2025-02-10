using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("{user1Id}/{user2Id}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByChatId(int user1Id, int user2Id)
        {
            var messages = await _messageRepository.GetMessagesByChatIdAsync(user1Id, user2Id);
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetById(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null) return NotFound();

            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> Create(CreateMessageDto createMessageDto)
        {
            var message = await _messageRepository.CreateAsync(createMessageDto);
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MessageDto>> Update(int id, CreateMessageDto updateMessageDto)
        {
            var message = await _messageRepository.UpdateAsync(id, updateMessageDto);
            if (message == null) return NotFound();

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _messageRepository.DeleteAsync(id);
            if (message == null) return NotFound();

            return NoContent();
        }
    }
}