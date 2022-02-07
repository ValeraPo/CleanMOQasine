using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CleanMOQasine.Data.Tests
{
    public class UserRepositoryTests
    {
        private UserTestData _userTestData;
        private CleanMOQasineContext _dbContext;
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _dbContext = new CleanMOQasineContext(opt);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _userRepository = new UserRepository(_dbContext);
    }

        [Test]
        public void GetUserById_ShoudReturnUserWithCertainId()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();
            _dbContext.Users.Add(userForTest);
            _dbContext.SaveChanges();
            var userId = userForTest.Id;

            //when
            var actual = _userRepository.GetUserById(userId);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(userId, actual.Id);
            Assert.IsNotNull(actual.Role);
            Assert.IsNotNull(actual.Orders);
            Assert.IsTrue(actual.Orders.Count > 0);
            Assert.IsNotNull(actual.CleaningAdditions);
            Assert.IsTrue(actual.CleaningAdditions.Count > 0);
            Assert.IsNotNull(actual.WorkingHours);
            Assert.IsTrue(actual.WorkingHours.Count > 0);
        }

        [Test]
        public void GetUserByLogin_ShoudReturnUserWithCertainLogin()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();
            _dbContext.Users.Add(userForTest);
            _dbContext.SaveChanges();

            //when
            var actual = _userRepository.GetUserByLogin(userForTest.Login);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(userForTest.Login, actual.Login);
            Assert.IsNotNull(actual.Role);
            Assert.IsNotNull(actual.Orders);
            Assert.IsTrue(actual.Orders.Count > 0);
            Assert.IsNotNull(actual.CleaningAdditions);
            Assert.IsTrue(actual.CleaningAdditions.Count > 0);
            Assert.IsNotNull(actual.WorkingHours);
            Assert.IsTrue(actual.WorkingHours.Count > 0);
        }

        [Test]
        public void GetUsers_ShoudReturnUsersWithRelativeEntities()
        {
            //given
            var usersForTest = _userTestData.GetListOfUsersForTests();

            foreach (var user in usersForTest)
            {
                _dbContext.Users.Add(user);
            }
            _dbContext.SaveChanges();

            //when
            var actual = _userRepository.GetUsers();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Orders);
            Assert.IsTrue(actual[0].Orders.Count > 0);
            Assert.IsNotNull(actual[0].CleaningAdditions);
            Assert.IsTrue(actual[0].CleaningAdditions.Count > 0);
            Assert.IsNotNull(actual[0].WorkingHours);
            Assert.IsTrue(actual[0].WorkingHours.Count > 0);
        }

        [Test]
        public void AddUser_ShoudAddUserToDb()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();

            //when
            _userRepository.AddUser(userForTest);

            //then
            //Assert.IsNotNull(actual);
        }
    }
}
