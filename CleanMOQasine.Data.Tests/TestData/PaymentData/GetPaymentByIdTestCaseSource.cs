using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class GetPaymentByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Payment payment1 = new Payment
            {
                Id = 1,
                PaymentDate = DateTime.Now,
                Amount = 100,
                IsDeleted = true
            };
            yield return new object[] { payment1, null };
            Payment payment2 = new Payment
            {
                Id = 2,
                PaymentDate = DateTime.Now.AddDays(-40),
                Amount = 1000,
                IsDeleted = false
            };
            yield return new object[] { payment2, payment2 };
        }
    }
}
