using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class PaymentRepository
    {
        private readonly CleanMOQasineContext _context;
        public PaymentRepository()
        {
            _context = CleanMOQasineContext.GetInstance();
        }

        //getOne
        public Payment GetPaymentById (int id) 
            => _context.Payment.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        //getall
        public IEnumerable<Payment> GetAllPayments () 
            => _context.Payment.Where(p => !p.IsDeleted).ToList();

        //delete
        public void DeletePayment(int id)
        {
            var oldPayment = _context.Payment.FirstOrDefault(p => p.Id == id);
            oldPayment.IsDeleted = true;
            _context.SaveChanges();
        }

        //update
        public void UpdatePayment(Payment newPayment)
        {
            var oldPayment = _context.Payment.FirstOrDefault(p => p.Id == newPayment.Id);
            oldPayment = newPayment;
            _context.SaveChanges();
        }

        //Addone
        public void AddPayment (Payment newPayment)
        {
            _context.Payment.Add(newPayment);
            _context.SaveChanges();
        }
    }
}
