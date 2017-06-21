using System;
using System.Collections.Generic;

namespace dogblog.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        List<Comment> Comments { get; set; }
        List<Blog> Blogs { get; set; }
        List<Review> Reviews { get; set; }
        List<Park> Parks { get; set; }

        public User(){
            Comments = new List<Comment>();
            Blogs = new List<Blog>();
            Reviews = new List<Review>();
            Parks = new List<Park>();

        }
    }
}