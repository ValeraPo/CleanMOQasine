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
            oldOrder = order;
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
