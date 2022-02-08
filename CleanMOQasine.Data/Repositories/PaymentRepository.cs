using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CleanMOQasineContext _context;
        public PaymentRepository(CleanMOQasineContext context)
        {
            _context = context;
        }

        public Payment GetPaymentById(int id)
            => _context.Payments.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        public List<Payment> GetAllPayments()
            => _context.Payments.Where(p => !p.IsDeleted).ToList();

        public int DeletePayment(int id)
        {
            var oldPayment = _context.Payments.FirstOrDefault(p => p.Id == id);
            oldPayment.IsDeleted = true;
            _context.SaveChanges();
            return 1;
        }

        public void UpdatePayment(Payment newPayment, int id)
        {
            newPayment.Id = id;
            var oldPayment = _context.Payments.FirstOrDefault(p => p.Id == newPayment.Id);
            oldPayment.Amount = newPayment.Amount;
            oldPayment.PaymentDate = newPayment.PaymentDate;
            _context.SaveChanges();
        }

        public void AddPayment(Payment newPayment, int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            newPayment.Order = order;
            _context.Payments.Add(newPayment);
            _context.SaveChanges();
        }
    }
}
