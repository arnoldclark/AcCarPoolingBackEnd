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
    }
}