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

        [Test]
        public void UpdateOrderTest()
        {
            // given
            var expected = _orderTestData.GetOrderForTests();
            _context.Orders.Add(expected);
            _context.SaveChanges();

            // when
            expected.Address = "другой";
            expected.CleaningType = new CleaningType { Name = "После пьянки", IsDeleted = false };
            expected.Date = System.DateTime.Now;
            expected.Grade = new Grade
            {
                IsAnonymous = true,
                Comment = "пфр",
                Rating = 3,
                IsDeleted = false,
            };
            expected.Rooms.Add(new Room
            {
                Name = "Опочивальня",
                IsDeleted = false,
                Price = 300
            });
            expected.CleaningAdditions.Add(new CleaningAddition
            {
                Name = "Убить паука",
                Price = 360,
                Duration = TimeSpan.FromDays(1),
                IsDeleted = false
            });
            
            _repository.UpdateOrder(expected);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddCleanerTest()
        {
            // given
            var expected = _orderTestData.GetOrderForTests();
            _context.Orders.Add(expected);
            _context.SaveChanges();
            var cleaner = new User
            {
                Email = "kusin@kmail.com",
                FirstName = "Петр",
                LastName = "Кузин",
                Login = "kusin",
                Password = "123qwe",
                PhoneNumber = "+7(917)234-44-55",
                IsDeleted = false,
                Role = Enums.Role.Cleaner,
            };

            // when
            _repository.AddCleaner(expected, cleaner);
            expected.Cleaners.Add(cleaner);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);

            // then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveCleanerTest()
        {
            // given
            var expected = _orderTestData.GetOrderForTests();
            var cleaner = new User
            {
                Email = "kusin@kmail.com",
                FirstName = "Петр",
                LastName = "Кузин",
                Login = "kusin",
                Password = "123qwe",
                PhoneNumber = "+7(917)234-44-55",
                IsDeleted = false,
                Role = Enums.Role.Cleaner,
            };
            expected.Cleaners.Add(cleaner);
            _context.Orders.Add(expected);
            _context.SaveChanges();
            

            // when
            _repository.RemoveCleaner(expected, cleaner);
            expected.Cleaners.Remove(cleaner);
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);

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
            expected.IsDeleted = true;
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);

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
            expected.IsDeleted = false;
            var actual = _context.Orders.FirstOrDefault(o => o.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
