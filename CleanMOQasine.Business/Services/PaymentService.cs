using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public PaymentModel GetPaymentById(int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            return AutoMapperToData.GetInstance().Map<PaymentModel>(payment);
        }

        public IEnumerable<PaymentModel> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return AutoMapperToData.GetInstance().Map<IEnumerable<PaymentModel>>(payments);
        }

        public int DeletePayment(int id)
        {
            if (_paymentRepository.DeletePayment(id) == -1)
                return -1;
            return 0;
        }
        public void UpdatePayment(PaymentModel payment, int id)
        {
            var upd = AutoMapperToData.GetInstance().Map<Payment>(payment);
            _paymentRepository.UpdatePayment(upd, id);
        }

        public void AddPayment(PaymentModel payment, int orderId)
        {
            var newPayment = AutoMapperToData.GetInstance().Map<Payment>(payment);
            _paymentRepository.AddPayment(newPayment);
        }
    }
}
 