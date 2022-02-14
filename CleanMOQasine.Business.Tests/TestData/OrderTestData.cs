using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class OrderTestData
    {
        public OrderModel GetOrderModelForTests()
        {
            return new OrderModel
            {
                Client = new UserModel
                {
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Data.Enums.Role.Client,
                },
                CleaningType = new CleaningTypeModel
                {
                    Name = "Самая простая",
                    Price = 100,
                    IsDeleted = false
                },
                Address = "Ленина 113",
                Date = new DateTime(2022, 02, 13, 3, 0, 0),
                IsDeleted = false,
                Rooms = new List<RoomModel>{
                    new RoomModel
                     {
                        Id = 1,
                        Name = "Чердак",
                        Price = 1000,
                        IsDeleted = false,
                     },
                    new RoomModel
                    {
                        Id = 1,
                        Name = "Кухня",
                        Price = 300,
                        IsDeleted = false
                    }
                },
                CleaningAdditions = new List<CleaningAdditionModel> {
                    new CleaningAdditionModel
                    {
                        Name = "Помыть шест",
                        Price = 343,
                        Duration = TimeSpan.FromDays(1),
                        IsDeleted = false
                    },
                    new CleaningAdditionModel
                    {
                        Name = "Искупать попугая",
                        Price = 400,
                        Duration = TimeSpan.FromDays(1),
                        IsDeleted = false
                    }
                },
                Cleaners = new List<UserModel> {
                    new UserModel
                    {
                        Email = "popova@mail.com",
                        FirstName = "Валентина",
                        LastName = "Попова",
                        Login = "popova",
                        Password = "popova",
                        PhoneNumber = "+7(911)567-87-90",
                        IsDeleted = false,
                        Role = Data.Enums.Role.Cleaner,
                    }
                }
                //TODO добавить когда появится пэймент
                //Payments = new List<PaymentModel>
                //{
                //    new PaymentModel
                //    {
                //        Amount = 100,
                //        PaymentDate = new DateTime(2022, 2, 12),
                //    },
                //    new PaymentModel
                //    {
                //        Amount = 150,
                //        PaymentDate = new DateTime(2022, 2, 10),
                //    },
                //}
            };
        }

        public Order GetOrderForTests()
        {
            return new Order
            {
                Client = new User
                {
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Data.Enums.Role.Client,
                },
                CleaningType = new CleaningType
                {
                    Name = "Самая простая",
                    Price = 100,
                    IsDeleted = false
                },
                Address = "Ленина 113",
                Date = new DateTime(2022, 02, 13, 3, 0, 0),
                IsDeleted = false,
                Rooms = new List<Room>{
                    new Room
                     {
                        Id = 1,
                        Name = "Чердак",
                        Price = 1000,
                        IsDeleted = false,
                     },
                    new Room
                    {
                        Id = 1,
                        Name = "Кухня",
                        Price = 300,
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
                        Role = Data.Enums.Role.Cleaner,
                    }
                }
                //TODO добавить когда появится пэймент
                //Payments = new List<Payment>
                //{
                //    new Payment
                //    {
                //        Amount = 100,
                //        PaymentDate = new DateTime(2022, 2, 12),
                //    },
                //    new Payment
                //    {
                //        Amount = 150,
                //        PaymentDate = new DateTime(2022, 2, 10),
                //    },
                //}
            };
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
                    Id = 1,
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Data.Enums.Role.Client,
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
                        Id = 2,
                        Email = "kusin@kmail.com",
                        FirstName = "Петр",
                        LastName = "Кузин",
                        Login = "kusin",
                        Password = "123qwe",
                        PhoneNumber = "+7(917)234-44-55",
                        IsDeleted = false,
                        Role = Data.Enums.Role.Cleaner,
                    }
                }
                //TODO добавить когда появится пэймент
                //Payments = new List<Payment>
                //{
                //    new Payment
                //    {
                //        Amount = 100,
                //        PaymentDate = new DateTime(2022, 2, 12),
                //        IsDeleted = false
                //    },
                //    new Payment
                //    {
                //        Amount = 150,
                //        PaymentDate = new DateTime(2022, 2, 10),
                //        IsDeleted = false
                //    },
                //}
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
                    Id = 3,
                    Email = "fluffy@mail.com",
                    FirstName = "Валентин",
                    LastName = "Петров",
                    Login = "fluffy",
                    Password = "fluffy",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Data.Enums.Role.Client,
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
                        Id = 4,
                        Email = "kusin@kmail.com",
                        FirstName = "Петр",
                        LastName = "Кузин",
                        Login = "kusin",
                        Password = "123qwe",
                        PhoneNumber = "+7(917)234-44-55",
                        IsDeleted = false,
                        Role = Data.Enums.Role.Cleaner,
                    }
                }
                //TODO добавить когда появится пэймент
                //Payments = new List<Payment>
                //{
                //    new Payment
                //    {
                //        Amount = 100,
                //        PaymentDate = new DateTime(2022, 1, 9),
                //        IsDeleted = false
                //    },
                //}
            },
        };

            return orders;
        }
        public List<Order> GetListOfOrdersForGetOrdersByCleanerIdTest()
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
                    Id = 1,
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Data.Enums.Role.Client,
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
                        Id = 2,
                        Email = "kusin@kmail.com",
                        FirstName = "Петр",
                        LastName = "Кузин",
                        Login = "kusin",
                        Password = "123qwe",
                        PhoneNumber = "+7(917)234-44-55",
                        IsDeleted = false,
                        Role = Data.Enums.Role.Cleaner,
                    }
                }
                //TODO добавить когда появится пэймент
                //Payments = new List<Payment>
                //{
                //    new Payment
                //    {
                //        Amount = 100,
                //        PaymentDate = new DateTime(2022, 2, 12),
                //        IsDeleted = false
                //    },
                //    new Payment
                //    {
                //        Amount = 150,
                //        PaymentDate = new DateTime(2022, 2, 10),
                //        IsDeleted = false
                //    },
                //}
            },

        };

            return orders;
        }

    }
}
