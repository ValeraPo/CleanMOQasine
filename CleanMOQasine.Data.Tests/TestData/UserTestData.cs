using CleanMOQasine.Data.Entities;
using System.Collections.Generic;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class UserTestData
    {
        public User GetUserForTests()
        {
            User user = new User
            {
                Email = "bugaga@mail.com",
                FirstName = "Сергей",
                LastName = "Бугаев",
                Login = "Bugai",
                Password = "fhryr352",
                PhoneNumber = "+7(921)765-45-23",
                IsDeleted = false,
                Role = Enums.Role.Client,
                Rank = 4.5666, 
                WorkingHours = new List<WorkingTime> { 
                    new WorkingTime { 
                        Id = 1, 
                        IsDeleted = false, 
                        Day = Enums.WeekDay.Thursday
                    }, 
                    new WorkingTime { 
                        Id = 2, 
                        IsDeleted = false, 
                        Day = Enums.WeekDay.Saturday 
                    }, 
                },
                Orders = new List<Order> {
                    new Order {
                        Id = 1,
                        IsDeleted = false
                    },
                    new Order {
                        Id = 2,
                        IsDeleted = false
                    },
                },
                CleaningAdditions = new List<CleaningAddition> {
                    new CleaningAddition
                    {
                        Id = 1,
                        Duration = System.TimeSpan.Zero,
                        IsDeleted = false,
                        Name = "Вынести мусор",
                        Price = 300
                    },
                    new CleaningAddition
                    {
                        Id = 2,
                        Duration = System.TimeSpan.Zero,
                        IsDeleted = false,
                        Name = "Помыть пол",
                        Price = 600
                    },
                }
            };
            return user;
        }

        public List<User> GetListOfUsersForTests()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Email = "bugaga@mail.com",
                FirstName = "Сергей",
                LastName = "Бугаев",
                Login = "Bugai",
                Password = "fhryr352",
                PhoneNumber = "+7(921)765-45-23",
                IsDeleted = false,
                Role = Enums.Role.Client,
                Rank = 4.5666,
                WorkingHours = new List<WorkingTime> {
                    new WorkingTime {
                        Id = 1,
                        IsDeleted = false,
                        Day = Enums.WeekDay.Thursday
                    },
                    new WorkingTime {
                        Id = 2,
                        IsDeleted = false,
                        Day = Enums.WeekDay.Saturday
                    },
                },
                Orders = new List<Order> {
                    new Order {
                        Id = 1,
                        IsDeleted = false
                    },
                    new Order {
                        Id = 2,
                        IsDeleted = false
                    },
                },
                CleaningAdditions = new List<CleaningAddition> {
                    new CleaningAddition
                    {
                        Id = 1,
                        Duration = System.TimeSpan.Zero,
                        IsDeleted = false,
                        Name = "Вынести мусор",
                        Price = 300
                    },
                    new CleaningAddition
                    {
                        Id = 2,
                        Duration = System.TimeSpan.Zero,
                        IsDeleted = false,
                        Name = "Помыть пол",
                        Price = 600
                    },
                },
                }
            };

            return users;
        }


    }
}
