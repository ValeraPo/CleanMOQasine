using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace CleanMOQasine.Data.Tests
{
    public class OrderRepositoryTests
    {
        private OrderTestData _orderTestData;
        private CleanMOQasineContext _context;
        private IOrderRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<CleanMOQasineContext>()
                          .UseInMemoryDatabase("Test")
                          .Options;

            _context = new CleanMOQasineContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repository = new OrderRepository(_context);
            _orderTestData = new OrderTestData();
        }

        [Test]
        public void GetOrderByIdTest()
        {
            // given
            var expected = _orderTestData.GetOrderForTests();
            _context.Orders.Add(expected);
            _context.SaveChanges();

            // when
            var actual = _repository.GetOrderById(expected.Id);
            expected = _orderTestData.GetOrderForTests();


            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrdersTest()
        {
            // given
            _context.Orders.AddRange(_orderTestData.GetListOfOrdersForTests());
            _context.SaveChanges();
            var expected = _orderTestData.GetListOfOrdersForTests();

            // when
            var actual = _repository.GetAllOrders();

            // then
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateOrderTest()
        {
            // given
            var prepared = _orderTestData.GetOrderForTests();
            _context.Orders.Add(prepared);
            _context.SaveChanges();
            var expected = _orderTestData.GetOrderForUpdateTests();

            // when
            _repository.UpdateOrder(prepared, expected);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == prepared.Id);

            // then
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Client.FirstName, actual.Client.FirstName); //TODO
            CollectionAssert.AreEqual(expected.Payments.Select(p => p.Amount), actual.Payments.Select(p => p.Amount)); //TODO переделать когда у Payment будет Equals
        }

        [Test]
        public void AddCleanerTest()
        {
            // given
            var expected = _orderTestData.GetOrderForTests();
            _context.Orders.Add(expected);
            _context.SaveChanges();
            var cleaner = _orderTestData.GetUserForTests();

            // when
            _repository.AddCleaner(expected, cleaner);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);
            expected = _orderTestData.GetOrderForTests();
            expected.Cleaners.Add(cleaner);

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveCleanerTest()
        {
            // given
            var expected = _orderTestData.GetOrderForTests();
            var cleaner = _orderTestData.GetUserForTests();
            expected.Cleaners.Add(cleaner);
            _context.Orders.Add(expected);
            _context.SaveChanges();
            

            // when
            _repository.RemoveCleaner(expected, cleaner);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);
            expected = _orderTestData.GetOrderForTests();

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddOrderTest()
        {
            //given
            var expected = _orderTestData.GetOrderForTests();

            //when
            _repository.AddOrder(expected);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);
            expected = _orderTestData.GetOrderForTests();

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeleteOrderTest()
        {
            //given
            var expected = _orderTestData.GetOrderForTests();
            _context.Orders.Add(expected);
            _context.SaveChanges();

            //when
            _repository.DeleteOrder(expected);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);
            expected = _orderTestData.GetOrderForTests();
            expected.IsDeleted = true;
            
            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RestoreOrderTest()
        {
            //given
            var expected = _orderTestData.GetOrderForTests();
            expected.IsDeleted = true;
            _context.Orders.Add(expected);
            _context.SaveChanges();

            //when
            _repository.RestoreOrder(expected);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);
            expected = _orderTestData.GetOrderForTests();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(AddPaymentTestCaseSource), nameof(AddPaymentTestCaseSource.AddPaymentData))]
        public void AddPayment(Payment payment, Order order)
        {
            //given
            _context.Orders.Add(order);
            _context.SaveChanges();

            //when
            _repository.AddPayment(payment, order);
            var actual = _context.Payments.FirstOrDefault(p => p.Id == payment.Id);

            //then
            Assert.AreEqual(payment, actual);
            Assert.AreEqual(order, actual.Order);
        }

    }
}
