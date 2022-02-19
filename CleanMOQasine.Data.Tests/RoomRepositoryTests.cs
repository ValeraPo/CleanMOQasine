using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace CleanMOQasine.Data.Tests
{
    public class RoomRepositoryTests
    {
        private RoomTestData _roomTestData;
        private CleanMOQasineContext _dbContext;
        private RoomRepository _roomRepository;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _dbContext = new CleanMOQasineContext(opt);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _roomTestData = new RoomTestData();
            _roomRepository = new RoomRepository(_dbContext);
        }

        [Test]
        public void GetRoomById_ShoudReturnRoomWithCertainId()
        {
            //given
            var roomForTest = _roomTestData.GetRoomForTests();
            _dbContext.Rooms.Add(roomForTest);
            _dbContext.SaveChanges();
            var roomId = roomForTest.Id;

            //when
            var actual = _roomRepository.GetRoomById(roomId);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(roomId, actual.Id);
            Assert.IsNotNull(actual.Orders);
            Assert.IsTrue(actual.Orders.Count > 0);
        }

        [Test]
        public void GetRooms_ShoudReturnRoomsFromDb()
        {
            //given

            //when
            var actual = _roomRepository.GetRooms();

            //then
            var rooms = _dbContext.Rooms.Where(u => !u.IsDeleted);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            CollectionAssert.AreEqual(rooms, actual);
        }

        [Test]
        public void AddRoom_ShoudAddRoomToDb()
        {
            //given
            var roomForTest = _roomTestData.GetRoomForTests();

            //when
            var addedRoomId = _roomRepository.AddRoom(roomForTest);
            var expected = _roomTestData.GetRoomForTests();
            expected.Id = addedRoomId;

            //then
            var actual = _dbContext.Rooms.FirstOrDefault(u => u.Id == addedRoomId);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateRoom_ShouldChangeIsDeletedPropertyOfRoom()
        {
            //given
            var isDeleted = true;

            //when
            _roomRepository.UpdateRoom(1, isDeleted);

            //then
            var updatedRoom = _dbContext.Rooms.FirstOrDefault(u => u.Id == 1);
            Assert.IsTrue(updatedRoom.IsDeleted == isDeleted);
        }

        [Test]
        public void UpdateRoom_ShouldUpdateRoomInDb()
        {
            //given
            var roomForTest = _roomTestData.GetRoomForTests();
            roomForTest.Id = 1;
            var roomToUpdate = _dbContext.Rooms.FirstOrDefault(u => u.Id == roomForTest.Id);

            //when
            _roomRepository.UpdateRoom(roomForTest);

            //then
            var updatedRoom = _dbContext.Rooms.FirstOrDefault(u => u.Id == roomForTest.Id);
            Assert.AreEqual(updatedRoom, roomForTest);
            Assert.IsTrue(roomToUpdate.IsDeleted == updatedRoom.IsDeleted);
        }
    }
}
