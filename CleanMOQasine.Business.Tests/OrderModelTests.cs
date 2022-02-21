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


        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        public void IsCompletedTest(int orderNumber, bool isCompleted)
        {
            //given
            var order = _orderTestData.MockInputOrderModel(orderNumber);
            var expected = isCompleted;

            //when
            var actual = order.IsCompleted;

            //then
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void TotalDurationTest(int orderNumber)
        {
            //given
            var order = _orderTestData.MockInputOrderModel(orderNumber);
            var expected = _orderTestData.MockOutpuTotalDuration(orderNumber);

            //when
            var actual = order.TotalDuration;

            //then
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, 0)]
        [TestCase(2, 2705)]
        [TestCase(3, 1712.6165233)]
        public void TotalPriceTest(int orderNumber, decimal price)
        {
            //given
            var order = _orderTestData.MockInputOrderModel(orderNumber);
            var expected = price;

            //when
            var actual = order.TotalPrice;

            //then
            Assert.AreEqual(actual, expected);
        }
    }
}
