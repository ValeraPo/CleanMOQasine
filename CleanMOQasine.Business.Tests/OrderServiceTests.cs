using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Exeptions;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CleanMOQasine.Business.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly OrderTestData _orderTestData;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _autoMapper;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _orderTestData = new OrderTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [Test]
        public void GetOrderByIdTest()
        {
            //given
            var order = _orderTestData.GetOrderForTests();
            _orderRepositoryMock.Setup(x => x.GetOrderById(It.IsAny<int>())).Returns(order);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);
            var expected = _autoMapper.Map<OrderModel>(order);

            //when
            var actual = sut.GetOrderById(expected.Id);

            //then
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetOrderByIdNegativeTest()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<EntityNotFoundException>(() => sut.GetOrderById(42));
        }

        [Test]
        public void GetAllOrdersTest()
        {
            //given
            var orders = _orderTestData.GetListOfOrdersForTests();
            _orderRepositoryMock.Setup(m => m.GetAllOrders()).Returns(orders);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //when
            var actual = sut.GetAllOrders();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Rooms);
            Assert.IsTrue(actual[0].Rooms.Count > 0);
            Assert.IsNotNull(actual[0].CleaningAdditions);
            Assert.IsTrue(actual[0].CleaningAdditions.Count > 0);
            Assert.IsNotNull(actual[0].Cleaners);
            Assert.IsTrue(actual[0].Cleaners.Count > 0);
            Assert.IsInstanceOf(typeof(OrderModel), actual[0]);
        }
        [Test]
        public void GetOrdersByCleanerIdTest()
        {
            //given
            var orders = _orderTestData.GetListOfOrdersForTests();
            _orderRepositoryMock.Setup(m => m.GetAllOrders()).Returns(orders);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //when
            var actual = sut.GetOrdersByCleanerId(2);

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count == 1);
            Assert.IsNotNull(actual[0].Rooms);
            Assert.IsTrue(actual[0].Rooms.Count > 0);
            Assert.IsNotNull(actual[0].CleaningAdditions);
            Assert.IsTrue(actual[0].CleaningAdditions.Count > 0);
            Assert.IsNotNull(actual[0].Cleaners);
            Assert.IsTrue(actual[0].Cleaners[0].Id == 2);
            Assert.IsInstanceOf(typeof(OrderModel), actual[0]);
        }

        [Test]
        public void UpdateOrderTest()
        {
            //TODO 
        }

        [Test]
        public void UpdateOrderNegativeTest()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<EntityNotFoundException>(() => sut.UpdateOrder(23, new OrderModel()));
        }

        [Test]
        public void AddOrderTest()
        {
            //TODO
        }

        [Test]
        public void AddCleanerTest()
        {
            //TODO
        }

            [Test]
        public void AddCleanerNegativeTest()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<EntityNotFoundException>(() => sut.AddCleaner(42, 42));
        }

        [Test]
        public void RemoveCleanerTest()
        {
            //TODO
        }

        [Test]
        public void RemoveCleanerNegativeTest()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<EntityNotFoundException>(() => sut.RemoveCleaner(42, 42));
        }

        [Test]
        public void RestoreOrderTest()
        {
            //TODO
        }

        [Test]
        public void RestoreOrderNegativeTest()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<EntityNotFoundException>(() => sut.RestoreOrder(42));
        }

        [Test]
        public void DeleteOrderTest()
        {
            //TODO
        }

        [Test]
        public void DeleteOrderNegativeTest()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            var sut = new OrderService(_orderRepositoryMock.Object, _userRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<EntityNotFoundException>(() => sut.DeleteOrder(42));
        }






    }
}