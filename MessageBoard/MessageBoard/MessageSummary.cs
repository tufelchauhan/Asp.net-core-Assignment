﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard
{
    public class MessageSummary
    {
        public int Id { get; set; }
        public string Text;
        public int LikesCount;
        public int CommentsCount;
    }
}
