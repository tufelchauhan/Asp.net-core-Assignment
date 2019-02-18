using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard
{
    public class MessageboardDbContext : DbContext
    {
        public MessageboardDbContext(DbContextOptions<MessageboardDbContext> options)
            : base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
