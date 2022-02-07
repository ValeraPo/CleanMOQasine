using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContext: DbContext
    {
        //private readonly string _connectionString = @"Data Source=80.78.240.16;Initial Catalog=CleanMOQasine;User ID=student;Password=qwe!23";
        //private readonly string _connectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=CleanMOQasine;Integrated Security=True";

        private static CleanMOQasineContext _instance;
        public CleanMOQasineContext(DbContextOptions<CleanMOQasineContext> options): base(options)
        {
            //Database.EnsureDeleted();
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
            
        //}

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
