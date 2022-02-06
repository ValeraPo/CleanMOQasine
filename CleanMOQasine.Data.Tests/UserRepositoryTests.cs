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
        private readonly UserTestData _userTestData;
        private CleanMOQasineContext _dbContext;

        public UserRepositoryTests()
        {
            _userTestData = new UserTestData();
        }

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _dbContext = new CleanMOQasineContext(opt);
        }

        [Test]
        public void GetUserById_ShoudReturnUserWithExactId()
        {
            //given
            var userForTest = _userTestData.GetUserForTests();

            //when


            //then
        }
       
    }
}
