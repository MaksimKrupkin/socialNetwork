using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetAll()
        {
            var messages = await _messageRepository.GetAllAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetById(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Create(Message messageModel)
        {
            var createdMessage = await _messageRepository.CreateAsync(messageModel);
            return CreatedAtAction(nameof(GetById), new { id = createdMessage.Id }, createdMessage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> Update(int id, Message messageModel)
        {
            var updatedMessage = await _messageRepository.UpdateAsync(id, messageModel);
            if (updatedMessage == null) return NotFound();
            return Ok(updatedMessage);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> Delete(int id)
        {
            var deletedMessage = await _messageRepository.DeleteAsync(id);
            if (deletedMessage == null) return NotFound();
            return Ok(deletedMessage);
        }
    }
}