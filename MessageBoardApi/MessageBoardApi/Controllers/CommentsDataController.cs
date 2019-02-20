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
    public class CommentsDataController : ControllerBase
    {
        private readonly IMessageBoardData MessageBoardData;

        public CommentsDataController(IMessageBoardData messageBoardData)
        {
            this.MessageBoardData = messageBoardData;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> getComments(int id)
        {
            return await MessageBoardData.GetComments(id);
        }

        [HttpPost("{str}")]
        public async Task<ActionResult<int>> addComment(string str)
        {
            return await MessageBoardData.AddComment(str);
        }
    }
}