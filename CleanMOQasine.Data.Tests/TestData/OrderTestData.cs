﻿using CleanMOQasine.Data.Entities;
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
                Id = 1,
                Address = "Ул. Ленина, 1",
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                IsDeleted = false,
                CleaningType = new CleaningType
                {
                    Name = "После ремонта",
                    Price = 1080,
                    IsDeleted = false
                },

                Client = new User
                {
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Enums.Role.Client,
                },
                Rooms = new List<Room> {
                    new Room
                    {
                        Name = "Комната грязи",
                        Price = 300,
                        IsDeleted = false
                    },
                    new Room
                    {
                        Name = "Кальянная",
                        Price = 228,
                        IsDeleted = false
                    }
                },
                CleaningAdditions = new List<CleaningAddition> {
                    new CleaningAddition
                    {
                        Name = "Помыть шест",
                        Price = 343,
                        Duration = TimeSpan.FromDays(1),
                        IsDeleted = false
                    },
                    new CleaningAddition
                    {
                        Name = "Искупать попугая",
                        Price = 400,
                        Duration = TimeSpan.FromDays(1),
                        IsDeleted = false
                    }
                },
                Cleaners = new List<User> {
                    new User
                    {
                        Email = "popova@mail.com",
                        FirstName = "Валентина",
                        LastName = "Попова",
                        Login = "popova",
                        Password = "popova",
                        PhoneNumber = "+7(911)567-87-90",
                        IsDeleted = false,
                        Role = Enums.Role.Cleaner,
                    }
                },
                Payments = new List<Payment>
                {
                    new Payment
                    {
                        Amount = 100,
                        PaymentDate = new DateTime(2022, 2, 12),
                        IsDeleted = false
                    },
                    new Payment
                    {
                        Amount = 150,
                        PaymentDate = new DateTime(2022, 2, 10),
                        IsDeleted = false
                    },
                }
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
