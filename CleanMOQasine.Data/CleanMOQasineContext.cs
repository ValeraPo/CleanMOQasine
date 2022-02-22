using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContext : DbContext
    {
        public CleanMOQasineContext(DbContextOptions<CleanMOQasineContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.CreateEntities();
            modelBuilder.SetOnDeleteNoAction();
            modelBuilder.Seed();
        }

        public DbSet<CleaningAddition> CleaningAdditions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CleaningType> CleaningTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<WorkingTime> WorkingHours { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}