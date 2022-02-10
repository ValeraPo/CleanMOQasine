using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
            _userTestData = new UserTestData();
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
            Assert.IsNotNull(actual.CleaningAdditions);
            Assert.IsTrue(actual.CleaningAdditions.Count > 0);
            Assert.IsNotNull(actual.WorkingHours);
            Assert.IsTrue(actual.WorkingHours.Count > 0);
        }

        [Test]
        public void GetUsers_ShoudReturnUsersFormDb()
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
            var users = _dbContext.Users.Where(u => !u.IsDeleted);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            CollectionAssert.AreEqual(users, actual);
        }

        [Test]
        public void AddUser_ShoudAddUserToDb()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();

            //when
            var addedUserId = _userRepository.AddUser(userForTest);

            //then
            var addedUser = _dbContext.Users.FirstOrDefault(u => u.Id == addedUserId);
            Assert.AreEqual(userForTest, addedUser);
        }

        [Test]
        public void UpdateUser_ShouldChangeIsDeletedPropertyOfUser()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();
            _dbContext.Users.Add(userForTest);
            _dbContext.SaveChanges();
            var isDeleted = true;

            //when
            _userRepository.UpdateUser(userForTest.Id, isDeleted);

            //then
            var updatedUser = _dbContext.Users.FirstOrDefault(u => u.Id == userForTest.Id);
            Assert.IsTrue(updatedUser.IsDeleted == isDeleted);
            Assert.AreEqual(userForTest, updatedUser);
        }

        [Test]
        public void UpdateUser_ShouldUpdateUserInDb()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();
            _dbContext.Users.Add(userForTest);
            _dbContext.SaveChanges();
            var userWithAnotherProperties = _userTestData.GetUpdatedUserForTests();

            //when
            _userRepository.UpdateUser(userWithAnotherProperties);

            //then
            var updatedUser = _dbContext.Users.FirstOrDefault(u => u.Id == userForTest.Id);
            Assert.AreEqual(updatedUser, userWithAnotherProperties);
        }
    }
}
