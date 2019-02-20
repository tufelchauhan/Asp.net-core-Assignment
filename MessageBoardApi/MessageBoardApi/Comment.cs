using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardApi
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int MessageId { get; set; }
    }
}
