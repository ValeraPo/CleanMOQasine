using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace CleanMOQasine.Business.Tests
{
    public class OrderModelTests
    {
        private readonly OrderModelTestData _orderTestData;

        public OrderModelTests()
        {
            _orderTestData = new OrderModelTestData();
        }


        [Test]
        public void IsCompletedTest()
        {
            //given
            var order = _orderTestData.GetOrderModelForTests();
            var expected = true;

            //when
            var actual = order.IsCompleted;

            //then
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TotalDurationTest()
        {
            //given
            var order = _orderTestData.GetOrderModelForTests();
            var expected = new TimeSpan(1, 16, 25, 0);

            //when
            var actual = order.TotalDuration;

            //then
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TotalPriceTest()
        {
            //given
            var order = _orderTestData.GetOrderModelForTests();
            var expected = 2705;

            //when
            var actual = order.TotalPrice;

            //then
            Assert.AreEqual(actual, expected);
        }
    }
}
