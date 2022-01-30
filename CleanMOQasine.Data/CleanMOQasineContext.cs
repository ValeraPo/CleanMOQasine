using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanMOQasine.Data
{
    public class CleanMOQasineContext: DbContext
    {
        private readonly string _connectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=CleanMOQasine;Integrated Security=True";

        public CleanMOQasineContext(DbContextOptions<CleanMOQasineContext> options):base(options)
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
            //modelBuilder.Seed();

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Grade)
            .WithOne(g => g.Order)
            .HasForeignKey<Grade>(o => o.OrderId);

            modelBuilder.Entity<Grade>()
            .HasOne(o => o.Order)
            .WithOne(g => g.Grade)
            .HasForeignKey<Order>(o => o.GradeId);

            modelBuilder.Entity<CleaningAddition>()
            .HasMany(p => p.Orders)
            .WithMany(b => b.CleaningAdditions)
            .UsingEntity<OrderCleaningAddition>(
                j => j.HasOne(i => i.Order)
                .WithMany(t => t.OrderCleaningAdditions)
                .HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(i => i.CleaningAddition)
                .WithMany(t => t.OrderCleaningAdditions)
                .HasForeignKey(o => o.CleaningAdditionId).OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<User>()
            .HasMany(p => p.CleanerOrders)
            .WithMany(b => b.Cleaners)
            .UsingEntity<OrderUser>(
                j => j.HasOne(i => i.Order)
                .WithMany(t => t.OrderUsers)
                .HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(i => i.User)
                .WithMany(t => t.OrderUsers)
                .HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<Order>()
            .HasOne(u => u.Client)
            .WithMany(c => c.Orders)
            .HasForeignKey(f => f.ClientId);
        }
    }
}
