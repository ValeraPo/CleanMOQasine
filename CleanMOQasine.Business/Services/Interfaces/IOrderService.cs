using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IOrderService
    {
        void AddCleaner(int idOrder, int idUser);
        OrderModel AddOrder(OrderModel orderModel);
        void DeleteOrder(int id);
        List<OrderModel> GetAllOrders();
        OrderModel GetOrderById(int id);
        void RemoveCleaner(int idOrderl, int idUser);
        void RestoreOrder(int id);
        void UpdateOrder(int id, OrderModel orderModel);
        List<OrderModel> GetOrdersByCleanerId(int idCleaner);
        List<OrderModel> GetOrdersByClientId(int idUser);
        void AddPayment(PaymentModel payment, int orderId);
        List<UserModel> SearchCleaners(OrderModel orderModel, int countCleaners);
    }
}