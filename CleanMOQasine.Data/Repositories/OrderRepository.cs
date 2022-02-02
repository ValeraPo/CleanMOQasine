using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository
    {
        private CleanMOQasineContext _dbContext;

        public OrderRepository() => _dbContext = Garbage.GetInstance().Context;

        public IEnumerable<Order> GetAllOrders() => _dbContext.Order.ToList();

        public Order GetOrderById(int id) => _dbContext.Order.FirstOrDefault(o => o.Id == id);

        public void UpdateOrder(Order order)
        {
            var oldOrder = _dbContext.Order.FirstOrDefault(o => o.Id == order.Id);
            oldOrder.ClientId = order.ClientId;
            oldOrder.Client = order.Client;
            oldOrder.CleaningType = order.CleaningType;
            oldOrder.GradeId = order.GradeId;
            oldOrder.Grade = order.Grade;
            oldOrder.Address = order.Address;
            oldOrder.TotalPrice = order.TotalPrice;
            oldOrder.TotalDuration = order.TotalDuration;
            oldOrder.Date = order.Date;
            oldOrder.IsCompleted = order.IsCompleted;
            oldOrder.Rooms = order.Rooms;
            oldOrder.OrderCleaningAdditions = order.OrderCleaningAdditions;
            oldOrder.CleaningAdditions = order.CleaningAdditions;
            oldOrder.OrderCleaners = order.OrderCleaners;
            oldOrder.Cleaners = order.Cleaners;
            oldOrder.Payments = order.Payments;

            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Order.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public void RestoreOrder(int id)
        {
            var order = _dbContext.Order.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();
        }
    }
}
