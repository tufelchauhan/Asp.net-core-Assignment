using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardApi
{
    public interface IMessageBoardData
    {
        Task<ActionResult<IEnumerable<MessageSummary>>> GetMessagesData();
        Task<ActionResult<IEnumerable<Comment>>> GetComments(int msgId);
        Task<ActionResult<int>> LikeMessage(int id);
        Task<ActionResult<int>> AddComment(string str);
        Task<ActionResult<int>> AddMessage(string str);
        void commit();
        //Task<ActionResult<IEnumerable<Comment>>> GetComments(int MessageId);
        //Message AddMessage(Message message);
        //Comment AddComment(Comment comment);
        ////Like AddLike(int Id);
        //IEnumerable<Message> GetMessages();
        //IEnumerable<MessageSummary> GetMessagesSummary();

        //IEnumerable<Like> GetLikes(int MessageId);

        //int GetLikesCount(int MessageId);
        //int GetCommentsCount(int MessageID);
    }
}
