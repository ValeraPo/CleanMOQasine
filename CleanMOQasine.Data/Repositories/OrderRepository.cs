using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository
    {
        private CleanMOQasineContext _info;

        public OrderRepository() => _info = Garbage.GetInstance().Context;

        public IEnumerable<Order> GetAllOrders() => _info.Order.ToList();

        public Order GetOrderById(int id)
        {
            Order order = _info.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
                throw new Exception($"Not found order with {id} to restore");
            return order;
        }

        public void UpdateOrder(Order order)
        {
            var oldOrder = _info.Order.FirstOrDefault(o => o.Id == order.Id);
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

            _info.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _info.Order.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            _info.SaveChanges();
        }

        public void RestoreOrder(int id)
        {
            var order = _info.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
                throw new Exception($"Not found order with {id} to restore");
            order.IsDeleted = true;
            _info.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            _info.Order.Add(order);
            _info.SaveChanges();
        }
    }
}
