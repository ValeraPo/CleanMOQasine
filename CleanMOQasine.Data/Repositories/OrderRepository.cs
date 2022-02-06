using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public OrderRepository() => _dbContext = CleanMOQasineContext.GetInstance();

        public Order GetOrderById(int id) => _dbContext.Orders.Include(o=>o.Grade).FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetAllOrders() => _dbContext.Orders.Where(o => !o.IsDeleted).ToList();

        public void UpdateOrder(Order order)
        {
            var oldOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
            oldOrder.CleaningType = order.CleaningType;
            oldOrder.Grade = order.Grade;
            oldOrder.Address = order.Address;
            oldOrder.Date = order.Date;
            oldOrder.Rooms = order.Rooms;
            oldOrder.CleaningAdditions = order.CleaningAdditions;
            Save(); 
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            Save();
        }

        public void AddCleaner(Order order, int idCleaner)
        {
            var oldOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
            var cleaner = _dbContext.Users.FirstOrDefault(u => u.Id == idCleaner);
            oldOrder.Cleaners.Add(cleaner);
            Save();
        }

        public void RemoveCleaner(Order order, int idCleaner)
        {
            var oldOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
            var cleaner = _dbContext.Users.FirstOrDefault(u => u.Id == idCleaner);
            oldOrder.Cleaners.Remove(cleaner);
            Save();
        }

        public void AddPayment(Order order, int idPayment)
        {
            var oldOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
            var payment = _dbContext.Payments.FirstOrDefault(p => p.Id == idPayment);
            oldOrder.Payments.Add(payment);
            Save();
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            Save();
        }

        public void RestoreOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            Save();
        }

        private void Save() => _dbContext.SaveChanges();
    }
}
