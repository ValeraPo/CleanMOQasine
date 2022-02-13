using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IPaymentService
    {
        void AddPayment(PaymentModel payment, int orderId);
        void DeletePayment(int id);
        IEnumerable<PaymentModel> GetAllPayments();
        PaymentModel GetPaymentById(int id);
        void UpdatePayment(PaymentModel payment, int id);
    }
}