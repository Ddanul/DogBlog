using System;
using System.Collections.Generic;

namespace dogblog.Models
{
    public class Review : BaseEntity
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}