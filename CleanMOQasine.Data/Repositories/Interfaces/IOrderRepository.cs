using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IOrderRepository
    {
        void AddCleaner(Order order, User cleaner);
        void AddOrder(Order order);
        void AddPayment(Order order, Payment payment);
        void DeleteOrder(int id);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void RemoveCleaner(Order order, User cleaner);
        void RestoreOrder(int id);
        void UpdateOrder(Order order);
    }
}