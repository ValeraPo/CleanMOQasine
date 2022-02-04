using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContext: DbContext
    {
        //private readonly string _connectionString = @"Data Source=80.78.240.16;Initial Catalog=CleanMOQasine;User ID=student;Password=qwe!23";
        private readonly string _connectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=CleanMOQasine;Integrated Security=True";

        private static CleanMOQasineContext _instance;
        public CleanMOQasineContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        
        public static CleanMOQasineContext GetInstance()
        {
            if (_instance == null)
                _instance = new CleanMOQasineContext();
            return _instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CreateEntities();
            modelBuilder.Seed();
        }

        public DbSet<CleaningAddition> CleaningAddition { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CleaningType> CleaningType { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<WorkingTime> WorkingTime { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
