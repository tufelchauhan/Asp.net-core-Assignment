using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesBoardController : ControllerBase
    {
        public readonly IMessageBoardData MessageBoardData;
        public MessagesBoardController(IMessageBoardData messageBoardData)
        {
            this.MessageBoardData = messageBoardData;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageSummary>>> GetMessages()
        {
            return await MessageBoardData.GetMessagesData();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<int>> LikeMessage(int id)
        {
            return await MessageBoardData.LikeMessage(id);
        }
    }
}