using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests.ModelTests
{
    public class UserModelTests
    {
        private UserModelTestData _testData;

        [SetUp]
        public void Setup()
        {
            _testData = new UserModelTestData();
        }

        [TestCase(1, 3)]
        [TestCase(2, 4.4)]
        [TestCase(3,null)]
        [TestCase(4,null)]
        [TestCase(5, null)]
        public void RankTest(int userNumber, double? expected)
        {
            //given
            var user = _testData.GetUsersForTest(userNumber);

            //when
            double? actual = user.Rank;

            //then
            Assert.AreEqual(actual, expected);
        }
    }
}
