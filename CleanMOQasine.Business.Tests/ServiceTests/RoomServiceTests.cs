using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Exceptions;
using Moq;
using NUnit.Framework;

namespace CleanMOQasine.Business.Tests
{
    public class RoomServiceTests
    {
        private Mock<IRoomRepository> _roomRepositoryMock;
        private readonly RoomTestData _roomTestData;
        private readonly IMapper _autoMapper;

        public RoomServiceTests()
        {
            _roomTestData = new RoomTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [SetUp]
        public void Setup()
        {
            _roomRepositoryMock = new Mock<IRoomRepository>();
        }

        [Test]
        public void GetRoomById_ShouldReturnRoomWithCertainId()
        {
            //given
            var room = _roomTestData.GetRoomForTests();
            _roomRepositoryMock.Setup(x => x.GetRoomById(It.IsAny<int>())).Returns(room);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);
            var expected = _autoMapper.Map<RoomModel>(room);

            //when
            var actual = sut.GetRoomById(1);

            //then
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual.Id, expected.Id);
        }

        [Test]
        public void GetRoomById_ShouldThrowCustomException()
        {
            //given
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns((Room)null);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.GetRoomById(23));
        }

        [Test]
        public void GetAllRooms_ShouldReturnRoomsWithOrders()
        {
            //given
            var rooms = _roomTestData.GetListOfRoomsForTests();
            _roomRepositoryMock.Setup(m => m.GetRooms()).Returns(rooms);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //when
            var actual = sut.GetAllRooms();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Orders);
            Assert.IsTrue(actual[0].Orders.Count > 0);
            Assert.IsInstanceOf(typeof(OrderModel), actual[0].Orders[0]);
        }

        [Test]
        public void AddRoom()
        {
            //given
            var roomModel = _roomTestData.GetRoomModelForTests();
            _roomRepositoryMock.Setup(m => m.AddRoom(It.IsAny<Room>())).Returns(23);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //when
            sut.AddRoom(roomModel);

            //then
            _roomRepositoryMock.Verify(m => m.AddRoom(It.IsAny<Room>()), Times.Once());
        }

        [Test]
        public void DeleteRoomById()
        {
            //given
            var room = new Room();
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns(room);
            _roomRepositoryMock.Setup(m => m.UpdateRoom(It.IsAny<int>(), true));
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //when
            sut.DeleteRoomById(23);

            //then
            _roomRepositoryMock.Verify(m => m.GetRoomById(It.IsAny<int>()), Times.Once());
            _roomRepositoryMock.Verify(m => m.UpdateRoom(It.IsAny<int>(), true), Times.Once());
        }

        [Test]
        public void DeleteRoomById_ShouldThrowCustomException()
        {
            //given
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns((Room)null);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteRoomById(23));
        }

        [Test]
        public void UpdateRoom()
        {
            //given
            var room = new Room();
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns(room);
            _roomRepositoryMock.Setup(m => m.UpdateRoom(room));
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //when
            sut.UpdateRoom(23, new RoomModel());

            //then
            _roomRepositoryMock.Verify(m => m.GetRoomById(It.IsAny<int>()), Times.Once());
            _roomRepositoryMock.Verify(m => m.UpdateRoom(room), Times.Once());
        }

        [Test]
        public void UpdateRoom_ShouldThrowCustomException()
        {
            //given
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns((Room)null);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.UpdateRoom(23, new RoomModel()));
        }

        [Test]
        public void RestoreRoomById()
        {
            //given
            var room = new Room();
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns(room);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //when
            sut.RestoreRoomById(23);

            //then
            _roomRepositoryMock.Verify(m => m.GetRoomById(It.IsAny<int>()), Times.Once());
            _roomRepositoryMock.Verify(m => m.UpdateRoom(It.IsAny<int>(), false), Times.Once());
        }

        [Test]
        public void RestoreRoomById_ShouldThrowCustomException()
        {
            //given
            _roomRepositoryMock.Setup(m => m.GetRoomById(It.IsAny<int>())).Returns((Room)null);
            var sut = new RoomService(_roomRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.RestoreRoomById(23));
        }
    }
}
