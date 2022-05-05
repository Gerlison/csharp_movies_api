using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(address => address.Theater)
                .WithOne(theater => theater.Address)
                .HasForeignKey<Theater>(theater => theater.AddressId);
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Theater> Theaters { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
