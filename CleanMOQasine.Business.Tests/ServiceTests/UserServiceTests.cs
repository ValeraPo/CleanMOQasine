using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Enums;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CleanMOQasine.Business.Tests
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private readonly UserTestData _userTestData;
        private readonly IMapper _autoMapper;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userTestData = new UserTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Test]
        public void GetUserById_ShouldReturnUserWithCertainId()
        {
            //given
            var user = _userTestData.GetUserForTests();
            _userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);
            var expected = _autoMapper.Map<UserModel>(user);

            //when
            var actual = sut.GetUserById(1);

            //then
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual.Id, expected.Id);
        }

        [Test]
        public void GetUserById_ShouldThrowCustomException()
        {
            //given
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.GetUserById(23));
        }

        [Test]
        public void GetAllAdmins_ShouldReturnAllUsersWithTheAdminRole()
        {
            //given
            var users = _userTestData.GetListOfUsersForTests();
            _userRepositoryMock.Setup(m => m.GetUsers()).Returns(users);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            var actual = sut.GetAllAdmins();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual[i].Role == Role.Admin);
                Assert.IsNotNull(actual[i].Id);
                Assert.IsNotNull(actual[i].Login);
                Assert.IsNotNull(actual[i].Password);
                Assert.IsNotNull(actual[i].PhoneNumber);
                Assert.IsNull(actual[i].Rank);
            }
        }

        [Test]
        public void GetAllCleaners_ShouldReturnAllUsersWithTheCleanerRole()
        {
            //given
            var users = _userTestData.GetListOfUsersForTests();
            _userRepositoryMock.Setup(m => m.GetUsers()).Returns(users);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            var actual = sut.GetAllCleaners();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual[i].Role == Role.Cleaner);
                Assert.IsNotNull(actual[i].Id);
                Assert.IsNotNull(actual[i].Login);
                Assert.IsNotNull(actual[i].Password);
                Assert.IsNotNull(actual[i].PhoneNumber);
                Assert.IsNotNull(actual[i].Rank);
                Assert.IsNotNull(actual[i].CleaningAdditions);
                Assert.IsNotNull(actual[i].WorkingHours);
                Assert.IsTrue(actual[i].CleaningAdditions.Count > 0);
                Assert.IsTrue(actual[i].WorkingHours.Count > 0);
            }
        }

        [Test]
        public void GetAllClients_ShouldReturnAllUsersWithTheClientRole()
        {
            //given
            var users = _userTestData.GetListOfUsersForTests();
            _userRepositoryMock.Setup(m => m.GetUsers()).Returns(users);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            var actual = sut.GetAllClients();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual[i].Role == Role.Client);
                Assert.IsNotNull(actual[i].Id);
                Assert.IsNotNull(actual[i].Login);
                Assert.IsNotNull(actual[i].Password);
                Assert.IsNotNull(actual[i].PhoneNumber);
                Assert.IsNotNull(actual[i].Rank);
            }
        }

        [Test]
        public void AddUser()
        {
            //given
            var userModel = _userTestData.GetUserModelForTests();
            _userRepositoryMock.Setup(m => m.AddUser(It.IsAny<User>())).Returns(23);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            sut.AddUser(userModel);

            //then
            _userRepositoryMock.Verify(m => m.AddUser(It.IsAny<User>()), Times.Once());
        }

        [Test]
        public void UpdateUser()
        {
            //given
            var user = new User();
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns(user);
            _userRepositoryMock.Setup(m => m.UpdateUser(user));
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            sut.UpdateUser(23, new UserModel());

            //then
            _userRepositoryMock.Verify(m => m.GetUserById(It.IsAny<int>()), Times.Once());
            _userRepositoryMock.Verify(m => m.UpdateUser(user), Times.Once());
        }

        [Test]
        public void UpdateUser_ShouldThrowCustomException()
        {
            //given
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.UpdateUser(23, new UserModel()));
        }

        [Test]
        public void DeleteUserById()
        {
            //given
            var user = new User();
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns(user);
            _userRepositoryMock.Setup(m => m.UpdateUser(It.IsAny<int>(), true));
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            sut.DeleteUserById(23);

            //then
            _userRepositoryMock.Verify(m => m.GetUserById(It.IsAny<int>()), Times.Once());
            _userRepositoryMock.Verify(m => m.UpdateUser(It.IsAny<int>(), true), Times.Once());
        }

        [Test]
        public void DeleteUserById_ShouldThrowCustomException()
        {
            //given
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteUserById(23));
        }

        [Test]
        public void RestoreUserById()
        {
            //given
            var user = new User();
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns(user);
            _userRepositoryMock.Setup(m => m.UpdateUser(It.IsAny<int>(), It.IsAny<bool>()));
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //when
            sut.RestoreUserById(23);

            //then
            _userRepositoryMock.Verify(m => m.GetUserById(It.IsAny<int>()), Times.Once());
            _userRepositoryMock.Verify(m => m.UpdateUser(It.IsAny<int>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void RestoreUserById_ShouldThrowCustomException()
        {
            //given
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);
            var sut = new UserService(_autoMapper, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteUserById(23));
        }
    }
}
