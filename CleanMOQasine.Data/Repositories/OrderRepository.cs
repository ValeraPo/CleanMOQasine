using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public OrderRepository(CleanMOQasineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetOrderById(int id) => _dbContext.Orders.Include(o => o.Grade).Include(o => o.Payments).FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetAllOrders() => _dbContext.Orders.Where(o => !o.IsDeleted).ToList();

        public void UpdateOrder(Order oldOrder, Order newOrder)
        {
            oldOrder.CleaningType = newOrder.CleaningType;
            oldOrder.Grade = newOrder.Grade;
            oldOrder.Address = newOrder.Address;
            oldOrder.Date = newOrder.Date;
            oldOrder.Rooms = newOrder.Rooms;
            oldOrder.CleaningAdditions = newOrder.CleaningAdditions;
            Save();
        }

        public List<Order> GetOrdersByCleaner(User cleaner)
        {
            var orders = new List<Order>();
            foreach (var order in GetAllOrders())
            {
                if (order.Cleaners.Contains(cleaner))
                    orders.Add(order);
            }
            return orders;
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
            order.IsDeleted = false;
            Save();
        }

        public void AddPayment(Payment newPayment, Order order)
        {
            newPayment.Order = order;
            _dbContext.Payments.Add(newPayment);
            _dbContext.SaveChanges();
        }

        private void Save() => _dbContext.SaveChanges();
    }
}
