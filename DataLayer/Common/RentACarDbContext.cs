using Bussines_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Common
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext() : base()
        {

        }

        public RentACarDbContext(DbContextOptions options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SQ0CA1F\\SQLEXPRESS;Database=RentACar;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CarCategory> CarCategories { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Location> Locations { get; set; }

    }
}
