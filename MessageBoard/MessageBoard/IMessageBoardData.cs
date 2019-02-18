using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard
{
    public interface IMessageBoardData
    {        
        Message AddMessage(Message message);
        Comment AddComment(Comment comment);
        //Like AddLike(int Id);
        IEnumerable<Message> GetMessages();
        IEnumerable<MessageSummary> GetMessagesSummary();
        IEnumerable<Like> GetLikes(int MessageId);
        IEnumerable<Comment> GetComments(int MessageId);
        int GetLikesCount(int MessageId);
        int GetCommentsCount(int MessageID);
        void Like(Like like);
        void commit();
    }
}
