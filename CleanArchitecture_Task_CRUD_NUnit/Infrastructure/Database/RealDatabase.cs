using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        { 
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
