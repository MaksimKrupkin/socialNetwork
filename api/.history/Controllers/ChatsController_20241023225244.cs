using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Dtos;
using api.Mappers; 
using api.Repository;

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

        // Получить все чаты с сообщениями и пользователями
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatDto>>> GetAll()
        {
            var chats = await _chatRepository.GetAllAsync();
            var chatDtos = chats.Select(ChatMapper.ToChatDto).ToList(); // Преобразуем чаты в DTO
            return Ok(chatDtos);
        }

        // Получить чат по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDto>> GetById(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null) return NotFound();

            var chatDto = ChatMapper.ToChatDto(chat); // Преобразуем в DTO
            return Ok(chatDto);
        }

        // Создать новый чат
[HttpPost]
public async Task<ActionResult<ChatDto>> Create(CreateChatDto chatDto)
{
    var chatModel = ChatMapper.ToChatModel(chatDto); // Маппинг без Id
    chatModel.CreatedAt = DateTime.UtcNow; // Устанавливаем дату создания
    
    var createdChat = await _chatRepository.CreateAsync(chatModel);
    var createdChatDto = ChatMapper.ToChatDto(createdChat); // Сгенерированный Id вернется в DTO
    
    return CreatedAtAction(nameof(GetById), new { id = createdChatDto.Id }, createdChatDto);
}

        // Обновить существующий чат
        [HttpPut("{id}")]
        public async Task<ActionResult<ChatDto>> Update(int id, ChatDto chatDto)
        {
            var chatModel = ChatMapper.ToChatModel(chatDto); // Преобразуем DTO в модель
            var updatedChat = await _chatRepository.UpdateAsync(id, chatModel);

            if (updatedChat == null) return NotFound();

            var updatedChatDto = ChatMapper.ToChatDto(updatedChat); // Преобразуем в DTO
            return Ok(updatedChatDto);
        }

        // Удалить чат
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChatDto>> Delete(int id)
        {
            var deletedChat = await _chatRepository.DeleteAsync(id);
            if (deletedChat == null) return NotFound();

            var deletedChatDto = ChatMapper.ToChatDto(deletedChat); // Преобразуем в DTO
            return Ok(deletedChatDto);
        }
    }
}