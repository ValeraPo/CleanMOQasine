using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class UpdatePaymentTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Payment payment1 = new Payment
            {
                Id = 5,
                PaymentDate = DateTime.Now,
                Amount = 1000,
                IsDeleted = false
            };
            Payment payment2 = new Payment
            {
                Id = 6,
                PaymentDate = DateTime.Now.AddDays(30),
                Amount = 666,
                IsDeleted = true
            };
            Payment payment3 = new Payment
            {
                Id = 7,
                PaymentDate = DateTime.Now.AddDays(-40),
                Amount = 85,
                IsDeleted = false
            };
            Payment payment4 = new Payment
            {
                Id = 8,
                PaymentDate = DateTime.Now.AddDays(-78),
                Amount = 999,
                IsDeleted = true
            };
            List<Payment> payments = new();
            payments.Add(payment1);
            payments.Add(payment2);
            payments.Add(payment3);
            payments.Add(payment4);
            yield return new object[] { payments, new Payment { Id = 7,
                                                              PaymentDate = DateTime.Now,
                                                              Amount = 90,
                                                              IsDeleted = false
                                                              }};
        }
    }
}
