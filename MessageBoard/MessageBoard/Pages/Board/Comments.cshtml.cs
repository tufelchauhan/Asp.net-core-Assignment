using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessageBoard.Pages.Board
{
    public class CommentsModel : PageModel
    {
        public IMessageBoardData messageBoardData { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string Message { get; set; }
        public CommentsModel(IMessageBoardData messageBoardData)
        {
            this.messageBoardData = messageBoardData;
        }

        public void OnGet(int id)
        {
            Comments = messageBoardData.GetComments(id);
            //return RedirectToPage("./Comments");
        }
    }
}