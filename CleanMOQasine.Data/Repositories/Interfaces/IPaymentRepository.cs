using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment newPayment);
        int DeletePayment(int id);
        IEnumerable<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void UpdatePayment(Payment newPayment, int id);
    }
}