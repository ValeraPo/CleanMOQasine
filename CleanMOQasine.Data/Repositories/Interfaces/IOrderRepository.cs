using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IOrderRepository
    {
        void AddCleaner(Order order, User cleaner);
        void AddOrder(Order order);
        void DeleteOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void RemoveCleaner(Order order, User cleaner);
        void RestoreOrder(Order order);
        void UpdateOrder(Order order);
    }
}