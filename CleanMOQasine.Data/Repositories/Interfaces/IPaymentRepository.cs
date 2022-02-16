using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IPaymentRepository
    {
        void DeletePayment(int id);
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void UpdatePayment(Payment newPayment);
    }
}