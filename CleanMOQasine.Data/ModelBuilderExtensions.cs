using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data
{
    public static class ModelBuilderExtensions
    {

        public static void CreateEntities(this ModelBuilder modelBuilder)
        {
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
            .UsingEntity<OrderCleaner>(
                j => j.HasOne(i => i.Order)
                .WithMany(t => t.OrderCleaners)
                .HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne(i => i.User)
                .WithMany(t => t.OrderCleaners)
                .HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<Order>()
            .HasOne(u => u.Client)
            .WithMany(c => c.ClientOrders)
            .HasForeignKey(f => f.ClientId);
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Name = "Жилая комната", Price = 1100, IsDeleted = false },
                new Room() { Id = 2, Name = "Гостиная", Price = 1300, IsDeleted = false },
                new Room() { Id = 3, Name = "Кухня", Price = 1300, IsDeleted = false },
                new Room() { Id = 4, Name = "Санузел", Price = 800, IsDeleted = false },
                new Room() { Id = 5, Name = "Гараж", Price = 1700, IsDeleted = false });

            modelBuilder.Entity<CleaningType>().HasData(
                new CleaningType() {Id = 1,  Name = "Поддерживающая", Price = 3000,  IsDeleted = false},
                new CleaningType() { Id = 2,  Name = "Генеральная", Price = 6000,  IsDeleted = false },
                new CleaningType() { Id = 3, Name = "После ремонта", Price = 8000, IsDeleted = false },
                new CleaningType() { Id = 4,  Name = "Мытье окон", Price = 2000, IsDeleted = false });

            modelBuilder.Entity<CleaningAddition>().HasData(
                new CleaningAddition() { Id = 1, Name = "Помыть пол", Price = 500, Duration = new TimeSpan(0, 30, 0), IsDeleted = false });
                //new CleaningAddition() { Name = "Почистить ковёр", Price = 700, Duration = new TimeSpan(0, 30, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Почистить мебель", Price = 900, Duration = new TimeSpan(1, 0, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Протереть пыль", Price = 500, Duration = new TimeSpan(0, 40, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть зеркала", Price = 400, Duration = new TimeSpan(0, 20, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Застелить постель", Price = 200, Duration = new TimeSpan(0, 15, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Сложить вещи", Price = 400, Duration = new TimeSpan(0, 30, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Вынести мусор", Price = 200, Duration = new TimeSpan(0, 15, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть люстру", Price = 600, Duration = new TimeSpan(0, 20, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Дезинфекция", Price = 500, Duration = new TimeSpan(0, 20, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Убраться в гардеробной", Price = 600, Duration = new TimeSpan(0, 30, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть окно изнутри", Price = 400, Duration = new TimeSpan(0, 15, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть окна на балконе изнутри", Price = 700, Duration = new TimeSpan(0, 45, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Убрать балкон", Price = 600, Duration = new TimeSpan(0, 35, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Погладить вещи", Price = 600, Duration = new TimeSpan(1, 0, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Доставить ключи", Price = 300, Duration = new TimeSpan(0, 40, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Забрать ключи", Price = 300, Duration = new TimeSpan(0, 40, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть раковину", Price = 400, Duration = new TimeSpan(0, 15, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть столешницу", Price = 200, Duration = new TimeSpan(0, 15, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть плиту", Price = 600, Duration = new TimeSpan(0, 25, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть обеденный стол", Price = 500, Duration = new TimeSpan(0, 30, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть посуду", Price = 600, Duration = new TimeSpan(0, 50, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть холодильник", Price = 500, Duration = new TimeSpan(0, 40, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть духовку", Price = 400, Duration = new TimeSpan(0, 30, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть микроволновку", Price = 300, Duration = new TimeSpan(0, 20, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть шкафы на кухне", Price = 800, Duration = new TimeSpan(1, 0, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть ванну или душевую", Price = 800, Duration = new TimeSpan(0, 40, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть унитаз", Price = 500, Duration = new TimeSpan(0, 25, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть биде", Price = 300, Duration = new TimeSpan(0, 20, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Помыть лоток", Price = 200, Duration = new TimeSpan(0, 10, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Убрать что-то ещё", Price = 400, Duration = new TimeSpan(0, 30, 0), IsDeleted = false },
                //new CleaningAddition() { Name = "Ебануть дробью", Price = 0, Duration = new TimeSpan(1, 0, 0), IsDeleted = false });
        }
    }
}
