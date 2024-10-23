using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Dtos;
using api.Mappers;

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

        // Get all messages for a specific chat
        [HttpGet("chat/{chatId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByChatId(int chatId)
        {
            var messages = await _messageRepository.GetMessagesByChatIdAsync(chatId);
            var messageDtos = messages.Select(MessageMapper.ToMessageDto).ToList(); // Convert to DTO
            return Ok(messageDtos);
        }

        // Get message by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetById(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null) return NotFound();

            var messageDto = MessageMapper.ToMessageDto(message); // Convert to DTO
            return Ok(messageDto);
        }

        // Create a new message
        [HttpPost]
        public async Task<ActionResult<MessageDto>> Create(CreateMessageDto createMessageDto)
        {
            // Convert CreateMessageDto to Message model
            var messageModel = MessageMapper.ToMessageModel(createMessageDto);

            var createdMessage = await _messageRepository.CreateAsync(messageModel);

            // Convert created message to MessageDto
            var createdMessageDto = MessageMapper.ToMessageDto(createdMessage);
            return CreatedAtAction(nameof(GetById), new { id = createdMessageDto.Id }, createdMessageDto);
        }

        // Update a message
        [HttpPut("{id}")]
        public async Task<ActionResult<MessageDto>> Update(int id, MessageDto messageDto)
        {
            var messageModel = MessageMapper.ToMessageModel(messageDto); // Convert DTO to model
            var updatedMessage = await _messageRepository.UpdateAsync(id, messageModel);

            if (updatedMessage == null) return NotFound();

            var updatedMessageDto = MessageMapper.ToMessageDto(updatedMessage); // Convert to DTO
            return Ok(updatedMessageDto);
        }

        // Delete a message
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageDto>> Delete(int id)
        {
            var deletedMessage = await _messageRepository.DeleteAsync(id);
            if (deletedMessage == null) return NotFound();

            var deletedMessageDto = MessageMapper.ToMessageDto(deletedMessage); // Convert to DTO
            return Ok(deletedMessageDto);
        }
    }
}