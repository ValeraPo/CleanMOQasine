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
            List<Payment> grades = new();
            grades.Add(payment1);
            grades.Add(payment2);
            grades.Add(payment3);
            grades.Add(payment4);
            yield return new object[] { grades, new Payment { Id = 7,
                                                              PaymentDate = DateTime.Now,
                                                              Amount = 90,
                                                              IsDeleted = false
                                                              }};
        }
    }
}
