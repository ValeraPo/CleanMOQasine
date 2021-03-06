using AutoMapper;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;

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

        public List<PaymentModel> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return _mapper.Map<List<PaymentModel>>(payments);
        }

        public void DeletePayment(int id)
        {
            GetPaymentById(id);
            _paymentRepository.DeletePayment(id);
        }

        public void UpdatePayment(PaymentModel payment)
        {
            var upd = _mapper.Map<Payment>(payment);
            _paymentRepository.UpdatePayment(upd);
        }

        public List<PaymentModel> GetPaymentsByClientId(int clientId)
        {
            var payments = _paymentRepository.GetAllPayments();
            List<PaymentModel> neededPayments = new();

            foreach(var pay in  payments)
            {
                if (pay.Order.Client.Id == clientId)
                    neededPayments.Add(_mapper.Map<PaymentModel>(pay));
            }
            return neededPayments;
        }

    }
}
 