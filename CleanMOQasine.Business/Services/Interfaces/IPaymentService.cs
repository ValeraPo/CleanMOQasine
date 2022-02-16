using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IPaymentService
    {
        void DeletePayment(int id);
        List<PaymentModel> GetAllPayments();
        PaymentModel GetPaymentById(int id);
        void UpdatePayment(PaymentModel payment);
    }
}