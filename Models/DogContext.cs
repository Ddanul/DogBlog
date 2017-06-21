using Microsoft.EntityFrameworkCore;
 
namespace dogblog.Models
{
    public class DogContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DogContext(DbContextOptions<DogContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}