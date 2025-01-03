using Microsoft.EntityFrameworkCore;
using Domain;
using ClassLibrary;

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
    }
}
