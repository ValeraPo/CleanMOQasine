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
            GetOrderForTests(),
                new Order
            {
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
                        Name = "Игральная",
                        Price = 300,
                        IsDeleted = false
                    },
                    new Room
                    {
                        Name = "Детская",
                        Price = 228,
                        IsDeleted = false
                    }
                },
                CleaningAdditions = new List<CleaningAddition>
                {
                    new CleaningAddition
                    {
                        Name = "Протереть книги",
                        Price = 343,
                        Duration = TimeSpan.FromDays(1),
                        IsDeleted = false
                    },
                    new CleaningAddition
                    {
                        Name = "Вымыть диван",
                        Price = 400,
                        Duration = TimeSpan.FromDays(1),
                        IsDeleted = false
                    }
                },
                Cleaners = new List<User>
                {
                    new User
                    {
                        Email = "kusin@kmail.com",
                        FirstName = "Петр",
                        LastName = "Кузин",
                        Login = "kusin",
                        Password = "123qwe",
                        PhoneNumber = "+7(917)234-44-55",
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
            },

                new Order
            {
                Address = "Ул. Матросова, 2",
                Date = new DateTime(2022, 2, 1, 8, 30, 52),
                IsDeleted = false,
                CleaningType = new CleaningType
                {
                    Name = "Самая простая",
                    Price = 100,
                    IsDeleted = false
                },
                Client = new User
                {
                    Email = "fluffy@mail.com",
                    FirstName = "Валентин",
                    LastName = "Петров",
                    Login = "fluffy",
                    Password = "fluffy",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Enums.Role.Client,
                },
                Rooms = new List<Room> {
                    new Room
                    {
                        Name = "Бильярд",
                        Price = 300,
                        IsDeleted = false
                    },
                    new Room
                    {
                        Name = "Собачья будка",
                        Price = 387,
                        IsDeleted = false
                    }
                },
                CleaningAdditions = new List<CleaningAddition>
                {
                    new CleaningAddition
                    {
                        Name = "Вымыть стены",
                        Price = 500,
                        Duration = TimeSpan.FromDays(2),
                        IsDeleted = false
                    },
                    new CleaningAddition
                    {
                        Name = "Пропылесосить",
                        Price = 322,
                        Duration = TimeSpan.FromDays(3),
                        IsDeleted = false
                    }
                },
                Cleaners = new List<User>
                {
                    new User
                    {
                        Email = "kusin@kmail.com",
                        FirstName = "Петр",
                        LastName = "Кузин",
                        Login = "kusin",
                        Password = "123qwe",
                        PhoneNumber = "+7(917)234-44-55",
                        IsDeleted = false,
                        Role = Enums.Role.Cleaner,
                    }
                },
                Payments = new List<Payment>
                {
                    new Payment
                    {
                        Amount = 100,
                        PaymentDate = new DateTime(2022, 1, 9),
                        IsDeleted = false
                    },
                }
            },
        };

            return orders;
        }
        public Order GetOrderForUpdateTests()
        {
            Order order = GetOrderForTests();
            order.Address = "другой";
            order.CleaningType = new CleaningType { Name = "После пьянки", IsDeleted = false };
            order.Date = System.DateTime.Now;
            order.Grade = new Grade
            {
                IsAnonymous = true,
                Comment = "пфр",
                Rating = 3,
                IsDeleted = false,
            };
            order.Rooms.Add(new Room
            {
                Name = "Опочивальня",
                IsDeleted = false,
                Price = 300
            });
            order.CleaningAdditions.Add(new CleaningAddition
            {
                Name = "Убить паука",
                Price = 360,
                Duration = TimeSpan.FromDays(1),
                IsDeleted = false
            });

            return order;
        }

        public User GetUserForTests()
        {
            return new User
            {
                Email = "bugaga@mail.com",
                FirstName = "Сергей",
                LastName = "Бугаев",
                Login = "Bugai",
                Password = "fhryr352",
                PhoneNumber = "+7(921)765-45-23",
                IsDeleted = false,
                Role = Enums.Role.Client,
                WorkingHours = new List<WorkingTime> {
                    new WorkingTime {
                        IsDeleted = false,
                        Day = Enums.WeekDay.Thursday
                    },
                    new WorkingTime {
                        IsDeleted = false,
                        Day = Enums.WeekDay.Saturday
                    },
                },
                CleaningAdditions = new List<CleaningAddition> {
                    new CleaningAddition
                    {
                        Duration = System.TimeSpan.Zero,
                        IsDeleted = false,
                        Name = "Вынести мусор",
                        Price = 300,
                        Orders = new List<Order> {
                            new Order {
                                Address ="Арктическая 7, кв 23",
                                Cleaners = new List<User> { }
                            }
                        }
                    },
                    new CleaningAddition
                    {
                        Duration = System.TimeSpan.Zero,
                        IsDeleted = false,
                        Name = "Помыть пол",
                        Price = 600,
                        Orders = new List<Order> {
                            new Order {
                                Address = "Арктическая 7, кв 23",
                                Cleaners = new List<User> { }
                            }
                        }
                    },
                },
                ClientOrders = new List<Order> {
                    new Order {
                        Address = "Арктическая 7, кв 23",
                        Cleaners =  new List<User> { }
                    }
                },
                CleanerOrders = new List<Order> {
                    new Order {
                        Address = "Арктическая 7, кв 23",
                        Cleaners = new List<User> { }
                    }
                }
            };
        }

    }
}
