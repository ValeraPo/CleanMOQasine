using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IOrderRepository
    {
        void AddCleaner(int idOrder, int idCleaner);
        void AddOrder(Order order);
        void DeleteOrder(int id);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void RemoveCleaner(int idOrder, int idCleaner);
        void RestoreOrder(int id);
        void UpdateOrder(int id, Order order);
    }
}