using CleanMOQasine.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using CleanMOQasine.Data.Tests.TestData;
using CleanMOQasine.Data.Entities;
using System.Linq;
using System.Collections.Generic;

namespace CleanMOQasine.Data.Tests
{
    public class Tests
    {
        private CleanMOQasineContext _context;
        private PaymentRepository _paymentRepository;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _context = new CleanMOQasineContext(opt);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _paymentRepository = new PaymentRepository(_context);
        }

        [TestCaseSource(typeof(GetPaymentByIdTestCaseSource))]
        public void GetPaymentByIdTest(Payment payment, Payment expected )
        {
            //given
            _context.Payments.Add(payment);
            _context.SaveChanges();
            //when
            var actual = _paymentRepository.GetPaymentById(payment.Id);
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllPaymentsTestCaseSource))]
        public void GetAllPayments(List<Payment> payments, List<Payment> expected)
        {
            //given
            _context.AddRange(payments);
            _context.SaveChanges();

            //when
            var actual = _paymentRepository.GetAllPayments();

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(UpdatePaymentTestCaseSource))]
        public void UpdatePayment(List<Payment> payments, Payment expected)
        {
            //given
            _context.AddRange(payments);
            _context.SaveChanges();

            //when
            _paymentRepository.UpdatePayment(expected, expected.Id);
            var actual = _context.Payments.FirstOrDefault(p => p.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}