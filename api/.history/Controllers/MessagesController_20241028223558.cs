using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("chat/{chatId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByChatId(int chatId)
        {
            return Ok(await _messageRepository.GetMessagesByChatIdAsync(chatId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetById(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Create(Message message)
        {
            var newMessage = await _messageRepository.CreateAsync(message);
            return CreatedAtAction(nameof(GetById), new { id = newMessage.Id }, newMessage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Message message)
        {
            var updatedMessage = await _messageRepository.UpdateAsync(id, message);
            if (updatedMessage == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMessage = await _messageRepository.DeleteAsync(id);
            if (deletedMessage == null) return NotFound();
            return NoContent();
        }
    }
}
