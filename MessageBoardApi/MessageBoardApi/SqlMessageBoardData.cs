using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardApi
{
    public class SqlMessageBoardData : IMessageBoardData
    {
        private readonly MessageBoardApi.MessageboardDbContext db;

        public SqlMessageBoardData(MessageboardDbContext db)
        {
            this.db = db;
        }
 
        public async Task<ActionResult<int>> LikeMessage(int id)
        {
            Like like = new Like();
            like.MessageId = id;
            db.Add(like);
            commit();
            return await Task.FromResult(id);
        }

        public async Task<ActionResult<int>> AddComment(string str)
        {
            string[] strarr = str.Split("|");
            int id = Int32.Parse(strarr[1]);
            Comment comment = new Comment();
            comment.CommentText = strarr[0];
            comment.MessageId = id;
            db.Add(comment);
            commit();
            return await Task.FromResult(id);
        }
        public async Task<ActionResult<int>> AddMessage(string str)
        {
            Message message = new Message();
            message.Messagetext = str;
            db.Add(message);
            commit();
            return await Task.FromResult(1);
        }
        public async Task<ActionResult<IEnumerable<MessageSummary>>> GetMessagesData()
        {
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
            return await query2_.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int MessageId)
        {
            var query = from c in db.Comments
                        where (c.MessageId == MessageId)
                        select c;
            return await query.ToListAsync();
        }

        public void commit()
        {
            db.SaveChanges();
        }

        



        //public IEnumerable<MessageSummary> GetMessagesSummary()
        //{
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

        //    var query_ = from m in db.Messages
        //                 join l in db.Likes on m.MessageId equals l.MessageId
        //                 into tmp
        //                 from tmp2 in tmp.DefaultIfEmpty()
        //                 join c in db.Comments on m.MessageId equals c.MessageId
        //                 into tmp3
        //                 from tmp4 in tmp3.DefaultIfEmpty()
        //                 select new MessageSummary
        //                 {
        //                     Id = m.MessageId,
        //                     Text = m.Messagetext,
        //                     LikesCount = tmp2 != null ? db.Likes.Count(ll => ll.MessageId == m.MessageId) : 0,
        //                     CommentsCount = tmp2 != null ? db.Comments.Count(jj => jj.MessageId == m.MessageId) : 0
        //                 };
        //    var query2_ = query_.GroupBy(g => g.Id, (key, group) => group.First());
        //    return query2_;
        //}

        //public Comment AddComment(Comment comment)
        //{
        //    db.Add(comment);
        //    commit();
        //    return comment;
        //}

        //public IEnumerable<Message> GetMessages()
        //{
        //    var query = db.Messages.Select(m => m);
        //    return query;
        //}

        //public int GetLikesCount(int MessageId)
        //{
        //    var query = db.Likes.Count();
        //    return query;
        //}

        //public Message AddMessage(Message message)
        //{
        //    db.Add(message);
        //    commit();
        //    return message;
        //}

        //public int GetCommentsCount(int MessageID)
        //{
        //    var query = db.Comments.Where(c => c.MessageId == MessageID).Count();
        //    return query;
        //}

        //public IEnumerable<Like> GetLikes(int MessageId)
        //{
        //    var query = db.Likes.Where(l => l.MessageId == MessageId);
        //    return query;
        //}

    }
}
