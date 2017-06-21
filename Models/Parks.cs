using System;
using System.Collections.Generic;

namespace dogblog.Models
{
    public class Park : BaseEntity
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Review> Reviews { get; set; }
        public Park(){
            Reviews = new List<Review>();
        }
    }
}