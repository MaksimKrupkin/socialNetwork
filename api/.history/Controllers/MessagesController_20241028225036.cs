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

        [HttpGet("{chatId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByChatId(int chatId)
        {
            var messages = await _messageRepository.GetMessagesByChatIdAsync(chatId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var message = await _messageRepository.CreateAsync(createMessageDto);
            return CreatedAtAction(nameof(GetMessagesByChatId), new { chatId = message.ChatId }, message);
        }
    }
}