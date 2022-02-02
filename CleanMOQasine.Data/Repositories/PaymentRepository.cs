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
        public class GradeRepository
        {
            protected Garbage Info = Garbage.GetInstance();
            public IEnumerable<Payment> GetAllPayments()
            {
                return Info.Context.Payment.Where(p => !p.IsDeleted).ToList();
            }
            public Payment GetPaymentById(int id)
            {
                return Info.Context.Payment.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
            }

            public void UpdatePaymentById(Payment payment)
            {
                var oldPayment = Info.Context.Payment.FirstOrDefault(p => p.Id == grade.Id);
                oldPayment = payment;
                Info.Context.SaveChanges();
            }
            public void DeletePayment(int id)
            {
                var oldPayment = Info.Context.Payment.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
                oldPayment.IsDeleted = true;
                Info.Context.SaveChanges();
                //ef check
            }
            public void AddPayment(Payment payment)
            {
                Info.Context.Payment.Add(payment);
                Info.Context.SaveChanges();
            }
        }
    }
}
