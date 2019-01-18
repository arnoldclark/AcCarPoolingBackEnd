using AcCarPooling.Models;
using Microsoft.EntityFrameworkCore;

namespace AcCarPooling.Database
{
    public class CarPoolContext : DbContext
    {

        public CarPoolContext(DbContextOptions<CarPoolContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Journey> Journeys { get; set; }

        public DbSet<LiftRequest> LiftRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<LiftRequest>()
            //    .HasOne(l => l.Passenger)
            //    .IsRequired().OnDelete(DeleteBehavior.Restrict);

        }


    }
}