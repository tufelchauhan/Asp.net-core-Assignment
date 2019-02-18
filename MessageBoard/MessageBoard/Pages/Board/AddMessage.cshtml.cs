using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MessageBoard.Pages.Board
{
    public class AddMessageModel : PageModel
    {
        [BindProperty]
        public Message msg { get; set; }
        private readonly IMessageBoardData messageBoardData;
        private readonly IHtmlHelper htmlHelper; 
        public AddMessageModel(IMessageBoardData messageBoardData,IHtmlHelper htmlHelper)
        {
            this.messageBoardData = messageBoardData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("hello");
            messageBoardData.AddMessage(msg);
            messageBoardData.commit();
            return RedirectToPage("./MessageList");
        }
    }
}