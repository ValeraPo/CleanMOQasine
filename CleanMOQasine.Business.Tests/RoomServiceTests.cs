using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CleanMOQasine.Business.Tests
{
    public class RoomServiceTests
    {
        private readonly Mock<IRoomRepository> _roomRepositoryMock;
        private readonly RoomTestData _roomTestData;
        private readonly IMapper _autoMapper;

        public RoomServiceTests()
        {
            _roomRepositoryMock = new Mock<IRoomRepository>();
            _roomTestData = new RoomTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [Test]
        public void GetAllRooms_ShouldReturnRoomsWithOrders()
        {
            //arrange
            var rooms = _roomTestData.GetListOfRoomsForTests();
            _roomRepositoryMock.Setup(m => m.GetRooms()).Returns(rooms);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //act
            var actual = sut.GetAllRooms();

            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Orders);
            Assert.IsTrue(actual[0].Orders.Count > 0);
            Assert.IsInstanceOf(typeof(OrderModel), actual[0].Orders[0]);
        }

        [Test]
        public void AddRoom()
        {
            //arrange
            var roomModel = _roomTestData.GetRoomModelForTests();
            _roomRepositoryMock.Setup(m => m.AddRoom(It.IsAny<Room>())).Returns(23);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //act
            sut.AddRoom(roomModel);

            //assert
            _roomRepositoryMock.Verify(m => m.AddRoom(It.IsAny<Room>()), Times.Once());
        }

        [Test]
        public void DeleteRoomById()
        {
            //arrange
            var room = new Room();
            _roomRepositoryMock.Setup(m => m.UpdateRoom(It.IsAny<int>(), true));
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns(room);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //act
            sut.DeleteRoomById(23);

            //assert
            _roomRepositoryMock.Verify(m => m.UpdateRoom(It.IsAny<int>(), true), Times.Once());
            _roomRepositoryMock.Verify(m => m.GetRoomById(It.IsAny<int>()), Times.Once());
        }
    }
}
