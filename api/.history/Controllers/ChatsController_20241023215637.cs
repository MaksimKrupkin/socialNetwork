using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Dtos;
using api.Mappers; // Подключаем мапперы

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
        public async Task<ActionResult<IEnumerable<ChatDto>>> GetAll()
        {
            var chats = await _chatRepository.GetAllAsync();
            var chatDtos = chats.Select(ChatMapper.ToChatDto).ToList(); // Используем маппер
            return Ok(chatDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDto>> GetById(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null) return NotFound();

            var chatDto = ChatMapper.ToChatDto(chat); // Используем маппер
            return Ok(chatDto);
        }

        [HttpPost]
        public async Task<ActionResult<ChatDto>> Create(Chat chatModel)
        {
            var createdChat = await _chatRepository.CreateAsync(chatModel);
            var chatDto = ChatMapper.ToChatDto(createdChat); // Используем маппер
            return CreatedAtAction(nameof(GetById), new { id = chatDto.Id }, chatDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChatDto>> Update(int id, Chat chatModel)
        {
            var updatedChat = await _chatRepository.UpdateAsync(id, chatModel);
            if (updatedChat == null) return NotFound();

            var chatDto = ChatMapper.ToChatDto(updatedChat); // Используем маппер
            return Ok(chatDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ChatDto>> Delete(int id)
        {
            var deletedChat = await _chatRepository.DeleteAsync(id);
            if (deletedChat == null) return NotFound();

            var chatDto = ChatMapper.ToChatDto(deletedChat); // Используем маппер
            return Ok(chatDto);
        }
    }
}