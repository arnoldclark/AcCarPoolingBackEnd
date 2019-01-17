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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<User>()
        //        .Property(j => j.JourneyId)
        //        .IsRequired(false);

        //}
    }
}