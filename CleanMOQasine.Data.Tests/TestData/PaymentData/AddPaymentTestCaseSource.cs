using CleanMOQasine.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class AddPaymentTestCaseSource
    {
        public static IEnumerable<TestCaseData> AddPaymentData()
        {
            Order order = new Order { Id = 1, Address = "Pushkina 1", Date = DateTime.Now, IsDeleted = false };
            Payment payment = new Payment { Id = 1, IsDeleted = false, Amount = 30, PaymentDate = DateTime.Now };
            yield return new TestCaseData(payment, order);
            Order order1 = new Order { Id = 2, Address = "Kukushkina 2", Date = DateTime.Now.AddDays(1), IsDeleted = false };
            Payment payment1 = new Payment { Id = 2, IsDeleted = false, Amount = 789, PaymentDate = DateTime.Now.AddDays(1) };
            yield return new TestCaseData(payment1, order1);
        }
    }
}


