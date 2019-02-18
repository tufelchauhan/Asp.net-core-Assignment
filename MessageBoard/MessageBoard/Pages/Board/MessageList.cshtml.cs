using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MessageBoard.Pages.Board
{
    public class MessageListModel : PageModel
    {
        //private readonly IConfiguration config;
        //private readonly ILogger<MessageListModel> logger;
        //public string message { get; set; }
        //public IEnumerable<Message> Messages { get; set; }

        public IMessageBoardData messageBoardData { get; set; }
        public IEnumerable<MessageSummary> MessagesSummary { get; set; }

        public MessageListModel(IMessageBoardData messageBoardData)
        {
            this.messageBoardData = messageBoardData;
            //this.config = config;
            //this.logger = logger;
        }

        public IActionResult OnGet(int id)
        {
            if(id != 0)
            {
                Like like = new Like();
                like.MessageId = id;
                messageBoardData.Like(like);
                messageBoardData.commit();
                return RedirectToPage("./MessageList");
            }
            MessagesSummary = messageBoardData.GetMessagesSummary();
            return Page();
        }
    }
}