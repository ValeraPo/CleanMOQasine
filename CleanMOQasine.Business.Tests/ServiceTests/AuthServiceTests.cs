using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using Moq;
using NUnit.Framework;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CleanMOQasine.Business.Tests.ServiceTests
{
    public class AuthServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private AuthServiceTestData _testData;


        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _testData = new AuthServiceTestData();
        }

        [Test]
        public void Login_ShouldReturnStringWithToken()
        {
            //given
            var user = _testData.GetUserForTests();
            _userRepositoryMock.Setup(x => x.GetUserByLogin(user.Login)).Returns(user);
            var sut = new AuthService(_userRepositoryMock.Object);
            //when
            var expected = sut.Login(user.Login, _testData.ValidPassword);
            var claimValues = new JwtSecurityTokenHandler().ReadJwtToken(expected).Claims.Select(c => c.Value);
            
            //then
            _userRepositoryMock.Verify(m=>m.GetUserByLogin(user.Login), Times.Once());
            Assert.IsNotNull(expected);
            Assert.IsNotEmpty(expected);
            Assert.IsInstanceOf<string>(expected);
            Assert.True(claimValues.Count() == 8);
            Assert.True(claimValues.Contains(user.FirstName));
            Assert.True(claimValues.Contains(user.LastName));
            Assert.True(claimValues.Contains(user.Role.ToString()));
            Assert.True(claimValues.Contains(user.Id.ToString()));
            Assert.True(claimValues.Contains(user.Email));
            Assert.True(claimValues.Contains(AuthOptions.Issuer));
            Assert.True(claimValues.Contains(AuthOptions.Audience));
            Assert.False(claimValues.Contains(user.PhoneNumber));
            Assert.False(claimValues.Contains(user.Rank.ToString()));
            Assert.False(claimValues.Contains(user.IsDeleted.ToString()));
        }

        [Test]
        public void Login_WithInvalidPassword_ShouldReturnAuthenticationException()
        {
            //given
            var user = _testData.GetUserForTests();
            _userRepositoryMock.Setup(x => x.GetUserByLogin(user.Login)).Returns(user);
            var sut = new AuthService(_userRepositoryMock.Object);

            //then
            Assert.Throws<AuthenticationException>(() => sut.Login(user.Login, It.IsAny<string>()));
            _userRepositoryMock.Verify(m => m.GetUserByLogin(user.Login), Times.Once());
        }

        [Test]
        public void Login_WithInvalidLogin_ShouldReturnAuthenticationException()
        {
            //given
            _userRepositoryMock.Setup(x => x.GetUserByLogin(It.IsAny<string>())).Returns((User)null);
            var sut = new AuthService(_userRepositoryMock.Object);

            //then
            Assert.Throws<AuthenticationException>(() => sut.Login(It.IsAny<string>(), It.IsAny<string>()));
            _userRepositoryMock.Verify(m => m.GetUserByLogin(It.IsAny<string>()), Times.Once());
        }

    }
}
