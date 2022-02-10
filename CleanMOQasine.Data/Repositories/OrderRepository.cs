using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CleanMOQasineContext _dbContext;
        public bool _isInitialized;

        public OrderRepository(CleanMOQasineContext context)
        {
            _dbContext = context;
            _isInitialized = true;
        }

        public Order GetOrderById(int id) => _dbContext.Orders.Include(o => o.Grade).FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetAllOrders() => _dbContext.Orders.Where(o => !o.IsDeleted).ToList();

        public void UpdateOrder(Order oldOrder, Order newOrder)
        {
            //var oldOrder = GetOrderById(newOrder.Id);
            oldOrder.CleaningType = newOrder.CleaningType;
            oldOrder.Grade = newOrder.Grade;
            oldOrder.Address = newOrder.Address;
            oldOrder.Date = newOrder.Date;
            oldOrder.Rooms = newOrder.Rooms;
            oldOrder.CleaningAdditions = newOrder.CleaningAdditions;
            Save();
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            Save();
        }

        public void AddCleaner(Order order, User cleaner)
        {
            order.Cleaners.Add(cleaner);
            Save();
        }

        public void RemoveCleaner(Order order, User cleaner)
        {
            order.Cleaners.Remove(cleaner);
            Save();
        }

        public void DeleteOrder(Order order)
        {
            order.IsDeleted = true;
            Save();
        }

        public void RestoreOrder(Order order)
        {
            order.IsDeleted = true;
            Save();
        }

        private void Save() => _dbContext.SaveChanges();
    }
}
