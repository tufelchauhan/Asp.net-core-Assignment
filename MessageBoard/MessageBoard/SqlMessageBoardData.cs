using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard
{
    public class SqlMessageBoardData : IMessageBoardData
    {
        private readonly MessageboardDbContext db;

        public SqlMessageBoardData(MessageboardDbContext db)
        {
            this.db = db;
        }

        public Comment AddComment(Comment comment)
        {
            
            db.Add(comment);
            commit();
            return comment;
        }
        public void Like(Like like)
        {
            db.Add(like);
            commit();
        }

        public Message AddMessage(Message message)
        {
            db.Add(message);
            commit();
            return message;
        }

        public IEnumerable<Comment> GetComments(int MessageId)
        {
            var query = db.Comments.Where(m => m.MessageId == MessageId);
            return query;                       
        }
        public int GetCommentsCount(int MessageID)
        {
            var query = db.Comments.Where(c => c.MessageId == MessageID).Count();
            return query;
        }

        public IEnumerable<Like> GetLikes(int MessageId)
        {
            var query = db.Likes.Where(l => l.MessageId == MessageId);
            return query;
        }

        public int GetLikesCount(int MessageId)
        {
            var query = db.Likes.Count();
            return query;
        }

        public IEnumerable<Message> GetMessages()
        {
            var query = db.Messages.Select(m=>m);
            return query;
        }

        public IEnumerable<MessageSummary> GetMessagesSummary()
        {
            //var query = db.Messages.Join(db.Likes,
            //                            m => m.MessageId,
            //                            l => l.MessageId,
            //                            (m, l) => new
            //                            {
            //                                m.MessageId,
            //                                m.Messagetext,
            //                                likesCount = db.Likes.Count(ll => ll.MessageId == m.MessageId)
            //                            })
            //                       .Join(db.Messages,
            //                             ma => ma.MessageId,
            //                             j => j.MessageId,
            //                             (ma, j) => new MessageSummary
            //                             {
            //                                 Id = ma.MessageId,
            //                                 Text = ma.Messagetext,
            //                                 LikesCount = ma.likesCount,
            //                                 CommentsCount = db.Comments.Count(jj => jj.MessageId == ma.MessageId)
            //                             }).ToList();
            //var query2 = query.GroupBy(g => g.Id, (key, group) => group.First());

            var query_ = from m in db.Messages
                         join l in db.Likes on m.MessageId equals l.MessageId
                         into tmp
                         from tmp2 in tmp.DefaultIfEmpty()
                         join c in db.Comments on m.MessageId equals c.MessageId
                         into tmp3
                         from tmp4 in tmp3.DefaultIfEmpty()
                         select new MessageSummary
                         {
                             Id = m.MessageId,
                             Text = m.Messagetext,
                             LikesCount = tmp2 != null ? db.Likes.Count(ll => ll.MessageId == m.MessageId) : 0,
                             CommentsCount = tmp2 != null ? db.Comments.Count(jj => jj.MessageId == m.MessageId) : 0
                         };
            var query2_ = query_.GroupBy(g => g.Id, (key, group) => group.First());
            return query2_;
        }

        public void commit()
        {
            db.SaveChanges();
        }
    }
}
