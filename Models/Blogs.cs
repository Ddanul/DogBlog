using System;
using System.Collections.Generic;

namespace dogblog.Models
{
    public class Blog : BaseEntity
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }

        public Blog(){
            Comments = new List<Comment>();

        }
    }
    
}