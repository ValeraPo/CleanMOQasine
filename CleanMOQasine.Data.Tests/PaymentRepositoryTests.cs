using CleanMOQasine.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
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
        private Mock<IPaymentRepository> mock = new Mock<IPaymentRepository>();

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _context = new CleanMOQasineContext(opt);
        }

        [TestCaseSource(typeof(GetPaymentByIdTestCaseSource))]
        public void GetPaymentByIdTest(Payment payment, Payment expected )
        {
            //given
            mock.Setup(obj => obj.GetPaymentById(payment.Id)).Returns(payment);
            _context.Payments.Add(payment);
            _context.SaveChanges();
            //when
            var repo = new PaymentRepository(_context);
            var actual = repo.GetPaymentById(payment.Id);
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllPaymentsTestCaseSource))]
        public void GetAllPayments(List<Payment> payments, List<Payment> expected)
        {
            //given
            mock.Setup(obj => obj.GetAllPayments()).Returns(expected);
            foreach (var pay in payments)
                _context.Payments.Add(pay);
            _context.SaveChanges();
            //when
            var repo = new PaymentRepository(_context);
            var actual = repo.GetAllPayments();
            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(UpdatePaymentTestCaseSource))]
        public void UpdatePayment(List<Payment> payments, Payment expected)
        {
            //given
            mock.Setup(obj => obj.UpdatePayment(expected, expected.Id));
            foreach (var pay in payments)
                _context.Payments.Add(pay);
            _context.SaveChanges();
            //when
            var repo = new PaymentRepository(_context);
            repo.UpdatePayment(expected, expected.Id);
            var actual = _context.Payments.FirstOrDefault(p => p.Id == expected.Id);
            //then
            Assert.AreEqual(expected, actual);
        }
    }
}