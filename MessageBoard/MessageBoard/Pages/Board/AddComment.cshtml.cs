using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MessageBoard.Pages.Board
{
    public class AddCommentModel : PageModel
    {
        [TempData]
        public string CommentText { get; set; }
        public Comment comment { get; set; }
        private readonly IMessageBoardData messageBoardData;
        private readonly IHtmlHelper htmlHelper;
        public AddCommentModel(IMessageBoardData messageBoardData, IHtmlHelper htmlHelper)
        {
            this.messageBoardData = messageBoardData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int id,string CommentText)
        {

            if(CommentText != null)
            {
                comment = new Comment();
                comment.MessageId = id;
                comment.CommentText = CommentText;
                messageBoardData.AddComment(comment);
                return RedirectToPage("./MessageList");
            }
            return Page();
        }
    }
}

