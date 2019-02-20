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
    public class MessageController : ControllerBase
    {
        private readonly IMessageBoardData MessageBoardData;
        public MessageController(IMessageBoardData messageBoardData)
        {
            this.MessageBoardData = messageBoardData;
        }
        [HttpPost("{text}")]
        public async Task<ActionResult<int>> AddMessage(string text)
        {
            return await MessageBoardData.AddMessage(text);
        }
    }
}