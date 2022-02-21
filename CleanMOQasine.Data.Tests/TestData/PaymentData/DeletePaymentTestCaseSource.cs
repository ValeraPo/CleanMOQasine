using CleanMOQasine.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class DeletePaymentTestCaseSource
    {
        public static IEnumerable<TestCaseData> DeletePaymentData()
        {
            Payment expected = new Payment { Id = 1, IsDeleted = true, Amount = 30, PaymentDate = DateTime.Now };
            Payment payment = new Payment { Id = 1, IsDeleted = false, Amount = 30, PaymentDate = expected.PaymentDate };
            yield return new TestCaseData(payment, expected);
            Payment expected2 = new Payment { Id = 2, IsDeleted = true, Amount = 55, PaymentDate = DateTime.Now.AddDays(1) };
            Payment payment2 = new Payment { Id = 2, IsDeleted = false, Amount = 55, PaymentDate = expected2.PaymentDate };
            yield return new TestCaseData(payment2, expected2);
        }
    }
}
