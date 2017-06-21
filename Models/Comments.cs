using System;
using System.Collections.Generic;

namespace dogblog.Models
{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int BlogId { get; set; }
        public Blog Blogs { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}