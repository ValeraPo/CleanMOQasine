using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment newPayment, int orderId);
        void DeletePayment(int id);
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void UpdatePayment(Payment newPayment, int id);
    }
}