using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Exeptions;
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
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public PaymentModel GetPaymentById(int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            if (payment is null)
                throw new NotFoundException($"Payment with id {id} does not exist");
            return _mapper.Map<PaymentModel>(payment);
        }

        public IEnumerable<PaymentModel> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return _mapper.Map<IEnumerable<PaymentModel>>(payments);
        }

        public void DeletePayment(int id)
        {
            GetPaymentById(id);
            _paymentRepository.DeletePayment(id);

        }
        
        public void UpdatePayment(PaymentModel payment, int id)
        {
            GetPaymentById(id);
            var upd = _mapper.Map<Payment>(payment);
            _paymentRepository.UpdatePayment(upd, id);
        }

        public void AddPayment(PaymentModel payment, int orderId)
        {
            var newPayment = _mapper.Map<Payment>(payment);
            _paymentRepository.AddPayment(newPayment, orderId);
        }
    }
}
 