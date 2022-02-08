using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;


namespace CleanMOQasine.Data.Tests.TestData
{
    public class OrderTestData
    {
        public Order GetOrderForTests()
        {
            var order = new Order
            {
                Address = "Ул. Ленина, 1",
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                IsDeleted = false,
                Rooms = new List<Room>(),
                CleaningAdditions = new List<CleaningAddition>(),
                Cleaners = new List<User>(),
                Payments = new List<Payment>()
            };
            return order;
        }

        public List<Order> GetListOfOrdersForTests()
        {
            List<Order> orders = new List<Order>
            {
                new Order
            {
                Address = "Ул. Ленина, 1",
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                IsDeleted = false,
                Rooms = new List<Room>(),
                CleaningAdditions = new List<CleaningAddition>(),
                Cleaners = new List<User>(),
                Payments = new List<Payment>()
            },
                new Order
            {
                Address = "Ул. Матросова, 2",
                Date = new DateTime(2022, 2, 1, 8, 30, 52),
                IsDeleted = true,
                Rooms = new List<Room>(),
                CleaningAdditions = new List<CleaningAddition>(),
                Cleaners = new List<User>(),
                Payments = new List<Payment>()
            },
                new Order
            {
                Address = "Ул. Ленина, 1",
                Date = new DateTime(2022, 2, 2, 8, 30, 52),
                IsDeleted = false,
                Rooms = new List<Room>(),
                CleaningAdditions = new List<CleaningAddition>(),
                Cleaners = new List<User>(),
                Payments = new List<Payment>()
            }
        };

            return orders;
        }
    }
}
