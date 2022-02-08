using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrdersTest()
        {
            // given
            var expected = _orderTestData.GetListOfOrdersForTests();
            _context.Orders.AddRange(expected);
            _context.SaveChanges();

            // when
            var actual = _repository.GetAllOrders();

            // then
            CollectionAssert.AreEqual(expected.Where(o => !o.IsDeleted), actual);
        }

        


    }
}
