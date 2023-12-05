using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bussines_Layer.Models;

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
            modelBuilder.Entity<CarReview>(entity =>
            entity.HasKey(cr => new { cr.ReviewId, cr.CarId }));
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CarCategory> CarCategories { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<CarReview> CarsReviews { get; set; }
    }
}
