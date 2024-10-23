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

        // Получить все сообщения для конкретного чата
        [HttpGet("chat/{chatId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByChatId(int chatId)
        {
            var messages = await _messageRepository.GetMessagesByChatIdAsync(chatId);
            var messageDtos = messages.Select(MessageMapper.ToMessageDto).ToList(); // Преобразуем в DTO
            return Ok(messageDtos);
        }

        // Получить сообщение по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetById(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null) return NotFound();

            var messageDto = MessageMapper.ToMessageDto(message); // Преобразуем в DTO
            return Ok(messageDto);
        }

        // Создать новое сообщение
[HttpPost]
public async Task<ActionResult<MessageDto>> Create(MessageDto messageDto)
{
    // Do not allow Id to be set manually for messages
    var messageModel = MessageMapper.ToMessageModel(messageDto);
    messageModel.Id = 0; // Reset Id to 0 to let the database generate it

    var createdMessage = await _messageRepository.CreateAsync(messageModel);

    var createdMessageDto = MessageMapper.ToMessageDto(createdMessage); 
    return CreatedAtAction(nameof(GetById), new { id = createdMessageDto.Id }, createdMessageDto);
}

        // Обновить сообщение
        [HttpPut("{id}")]
        public async Task<ActionResult<MessageDto>> Update(int id, MessageDto messageDto)
        {
            var messageModel = MessageMapper.ToMessageModel(messageDto); // Преобразуем DTO в модель
            var updatedMessage = await _messageRepository.UpdateAsync(id, messageModel);

            if (updatedMessage == null) return NotFound();

            var updatedMessageDto = MessageMapper.ToMessageDto(updatedMessage); // Преобразуем в DTO
            return Ok(updatedMessageDto);
        }

        // Удалить сообщение
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageDto>> Delete(int id)
        {
            var deletedMessage = await _messageRepository.DeleteAsync(id);
            if (deletedMessage == null) return NotFound();

            var deletedMessageDto = MessageMapper.ToMessageDto(deletedMessage); // Преобразуем в DTO
            return Ok(deletedMessageDto);
        }
    }
}