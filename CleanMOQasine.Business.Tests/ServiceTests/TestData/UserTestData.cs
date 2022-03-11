using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Enums;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class UserTestData
    {
        public UserModel GetUserModelForTests()
        {
            UserModel userModel = new UserModel
            {
                Id = 1,
                Email = "bugaga@mail.com",
                FirstName = "Сергей",
                LastName = "Бугаев",
                Login = "Bugai",
                Password = "fhryr352",
                PhoneNumber = "+7(921)765-45-23",
                IsDeleted = false,
                Role = Role.Client,
                CleaningAdditions = new List<CleaningAdditionModel> {
                    new CleaningAdditionModel { },
                    new CleaningAdditionModel { }
                },
                Orders = new List<OrderModel> {
                    new OrderModel { },
                    new OrderModel { }
                },
                WorkingHours = new List<WorkingTimeModel> {
                    new WorkingTimeModel { },
                    new WorkingTimeModel { }
                }
            };

            return userModel;
        }

        public User GetUserForTests()
        {
            User user = new User
            {
                Id = 1,
                Email = "bugaga@mail.com",
                FirstName = "Сергей",
                LastName = "Бугаев",
                Login = "Bugai",
                Password = "fhryr352",
                PhoneNumber = "+7(921)765-45-23",
                IsDeleted = false,
                Role = Role.Cleaner,
                CleaningAdditions = new List<CleaningAddition> {
                    new CleaningAddition { },
                    new CleaningAddition { }
                },
                WorkingHours = new List<WorkingTime> {
                    new WorkingTime { },
                    new WorkingTime { }
                },
                CleanerOrders = new List<Order> {
                    new Order { },
                    new Order { }
                },
                ClientOrders = new List<Order> {
                    new Order { },
                    new Order { }
                }
            };

            return user;
        }

        public List<User> GetListOfUsersForTests()
        {
            List<User> users = new List<User> {
                new User {
                    Id = 1,
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Role.Client,
                    CleaningAdditions = new List<CleaningAddition> {
                        new CleaningAddition { },
                        new CleaningAddition { }
                    },
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime { },
                        new WorkingTime { }
                    }
                },
                new User {
                    Id = 1,
                    Email = "bugaga@mail.com",
                    FirstName = "Павел",
                    LastName = "Прилучный",
                    Login = "YOHOHO",
                    Password = "fhryr352",
                    PhoneNumber = "+7(777)777-77-77",
                    IsDeleted = false,
                    Role = Role.Client,
                    CleaningAdditions = new List<CleaningAddition> {
                        new CleaningAddition { },
                        new CleaningAddition { },
                        new CleaningAddition { }
                    },
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime { },
                        new WorkingTime { },
                        new WorkingTime { }
                    }
                },
                new User {
                    Id = 1,
                    Email = "clean@mail.com",
                    FirstName = "Максим",
                    LastName = "Чистюля",
                    Login = "Chistit'",
                    Password = "myt'23",
                    PhoneNumber = "+79116534523",
                    IsDeleted = false,
                    Role = Role.Cleaner,
                    CleaningAdditions = new List<CleaningAddition> {
                        new CleaningAddition { },
                        new CleaningAddition { }
                    },
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime { },
                        new WorkingTime { }
                    }
                },
                new User {
                    Id = 1,
                    Email = "voll@mail.com",
                    FirstName = "Сынок",
                    LastName = "Воля",
                    Login = "Volya",
                    Password = "oldshgf2435",
                    PhoneNumber = "+76666666666",
                    IsDeleted = false,
                    Role = Role.Cleaner,
                    CleaningAdditions = new List<CleaningAddition> {
                        new CleaningAddition { },
                        new CleaningAddition { },
                        new CleaningAddition { }
                    },
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime { },
                        new WorkingTime { },
                        new WorkingTime { }
                    }
                },
                new User {
                    Id = 1,
                    Email = "kolobokkk@mail.com",
                    FirstName = "Колобок",
                    LastName = "Жураев",
                    Login = "kolobok23",
                    Password = "tratata33",
                    PhoneNumber = "+79217666534",
                    IsDeleted = false,
                    Role = Role.Admin
                },
                new User {
                    Id = 1,
                    Email = "petr@mail.com",
                    FirstName = "Петр",
                    LastName = "Починников",
                    Login = "Yoptr",
                    Password = "petra333",
                    PhoneNumber = "+79818888888",
                    IsDeleted = false,
                    Role = Role.Admin
                }
            };

            return users;
        }

        public List<User> GetListOfCleanersForTests()
        {
            List<User> users = new List<User> {
                new User {
                    Id = 1,
                    Email = "bugaga@mail.com",
                    FirstName = "Сергей",
                    LastName = "Бугаев",
                    Login = "Bugai",
                    Password = "fhryr352",
                    PhoneNumber = "+7(921)765-45-23",
                    IsDeleted = false,
                    Role = Role.Cleaner,
                    //CleanerOrders = 
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
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime {
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(18,0),
                             Day = WeekDay.Monday
                        },
                        new WorkingTime {
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(16,0),
                             Day = WeekDay.Friday
                        }
                    }
                },
                new User {
                    Id = 1,
                    Email = "clean@mail.com",
                    FirstName = "Максим",
                    LastName = "Чистюля",
                    Login = "Chistit'",
                    Password = "myt'23",
                    PhoneNumber = "+79116534523",
                    IsDeleted = false,
                    Role = Role.Cleaner,
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
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime{
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(18,0),
                             Day = WeekDay.Tuesday
                        },
                        new WorkingTime{
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(18,0),
                             Day = WeekDay.Wednesday
                        }
                    }
                },
                new User {
                    Id = 1,
                    Email = "voll@mail.com",
                    FirstName = "Сынок",
                    LastName = "Воля",
                    Login = "Volya",
                    Password = "oldshgf2435",
                    PhoneNumber = "+76666666666",
                    IsDeleted = false,
                    Role = Role.Cleaner,
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
                    WorkingHours = new List<WorkingTime> {
                        new WorkingTime {
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(18,0),
                             Day = WeekDay.Wednesday
                        },
                        new WorkingTime {
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(18,0),
                             Day = WeekDay.Monday
                        },
                        new WorkingTime {
                             StartTime = new TimeOnly(9, 0),
                             EndTime = new TimeOnly(18,0),
                             Day = WeekDay.Thursday
                        }
                    }
                }
            };

            return users;
        }
    }
}