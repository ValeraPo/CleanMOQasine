using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContext: DbContext
    {
        private readonly string _connectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Database=CleanMOQasine;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False";

        protected CleanMOQasineContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<CleaningAddition> CleaningAddition { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CleaningType> CleaningType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<WorkingTime> WorkingTime { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
