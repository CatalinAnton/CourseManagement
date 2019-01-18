using System.Collections.Generic;
using ChatAPI.Models;
using ChatAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public ActionResult<List<Chat>> Get()
        {
            return _chatService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetByCourse")]
        public ActionResult<Chat> GetByCourseId(string id)
        {
            var chat = _chatService.GetByCourseId(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        [HttpPost]
        public ActionResult<Chat> Create(Chat chat)
        {
            _chatService.Create(chat);

            return CreatedAtRoute("GetByCourse", new { id = chat._id.ToString() }, chat);
        }
    }
}