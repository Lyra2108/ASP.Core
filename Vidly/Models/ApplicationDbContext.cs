using Microsoft.EntityFrameworkCore;

namespace Vidly.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType {Id = 1, SignUpFee = 0, DurationInMonth = 0, DiscountRate = 0},
                new MembershipType {Id = 2, SignUpFee = 30, DurationInMonth = 1, DiscountRate = 10},
                new MembershipType {Id = 3, SignUpFee = 90, DurationInMonth = 3, DiscountRate = 15},
                new MembershipType {Id = 4, SignUpFee = 300, DurationInMonth = 12, DiscountRate = 20}
            );
        }
    }
}
