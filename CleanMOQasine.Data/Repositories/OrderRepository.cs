using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository
    {
        Garbage Info = Garbage.GetInstance();
        public IEnumerable<Order> GetAllOrders()
        {
            return Info.Context.Order.Where(o => !o.IsDeleted).ToList();
        }
        public Order GetOrderById(int id)
        {
            return Info.Context.Order.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        }

        public void UpdateOrder(Order order)
        {
            var oldOrder = Info.Context.Order.FirstOrDefault(o => o.Id == order.Id && !o.IsDeleted);
            oldOrder = order;
            Info.Context.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var order = Info.Context.Order.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (order == null)
                throw new Exception($"Not found order with {id} to restore");

            foreach (var orderCleaner in order.OrderCleaners)
                orderCleaner.IsDeleted = true;
            foreach (var orderCleaningAdd in order.OrderCleaningAdditions)
                orderCleaningAdd.IsDeleted = true;
            foreach(var payment in order.Payments)
                payment.IsDeleted = true;
            order.Grade.IsDeleted = true;

            order.IsDeleted = true;
            Info.Context.SaveChanges();
        }
        public void RestoreOrder(int id)
        {
            var order = Info.Context.Order.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (order == null)
                throw new Exception($"Not found order with {id} to restore");
            order.IsDeleted = true;
            Info.Context.SaveChanges();
        }
        public void AddOrder(Order order)
        {
            Info.Context.Order.Add(order);
            Info.Context.SaveChanges();
        }
    }
}
