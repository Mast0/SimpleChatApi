using Microsoft.AspNetCore.Mvc;
using SimpleChatApi.Logic.Models;
using SimpleChatApi.Logic.Services.Interfaces;

namespace SimpeChatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService service;

        public ChatController(IChatService chatService)
        {
            service = chatService;
        }

        [HttpGet]
        public IActionResult GetChats()
        {
            var chats = service.GetAll();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public IActionResult GetChat(int id)
        {
            var chat = service.GetById(id);
            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }

        [HttpPost]
        public IActionResult CreateChat([FromBody] CreateChatRequest req)
        {
            var chat = service.Add(new ChatModel(service.GetAll().Count() + 1, req.Name, req.CreatedBy));
            return CreatedAtAction(nameof(GetChat), new { chatId = chat.Id }, chat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChat(int id, [FromBody] DeletedChatRequest req)
        {
            try
            {
                service.Delete(req.UserId, id);
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
        }
    }

    public class CreateChatRequest
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
    }

    public class DeletedChatRequest
    {
        public string UserId { get; set; }
    }
}
