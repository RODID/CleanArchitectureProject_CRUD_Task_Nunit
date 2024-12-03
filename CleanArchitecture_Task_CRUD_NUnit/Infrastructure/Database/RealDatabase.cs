using Microsoft.EntityFrameworkCore;
using Domain;
using ClassLibrary;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        private readonly IConfiguration _configuration;
        public RealDatabase(DbContextOptions<RealDatabase> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
