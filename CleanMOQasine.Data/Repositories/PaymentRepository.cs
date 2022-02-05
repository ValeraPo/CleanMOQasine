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
            => _context.Payment.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        public IEnumerable<Payment> GetAllPayments()
            => _context.Payment.Where(p => !p.IsDeleted).ToList();

        public int DeletePayment(int id)
        {
            var oldPayment = _context.Payment.FirstOrDefault(p => p.Id == id);
            if (oldPayment.IsDeleted == true)
                return -1;
            oldPayment.IsDeleted = true;
            _context.SaveChanges();
            return 0;
        }

        public void UpdatePayment(Payment newPayment, int id)
        {
            newPayment.Id = id;
            var oldPayment = _context.Payment.FirstOrDefault(p => p.Id == newPayment.Id);
            oldPayment = newPayment;
            _context.SaveChanges();
        }

        public void AddPayment(Payment newPayment)
        {
            _context.Payment.Add(newPayment);
            _context.SaveChanges();
        }
    }
}
