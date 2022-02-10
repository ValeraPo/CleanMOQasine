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

            return user;
        }

        public User GetUpdatedUserForTests()
        {
            User user = new User
            {
                Id = 1,
                Email = "bugaga@mail.com",
                FirstName = "Павел",
                LastName = "Прилучный",
                Login = "YOHOHO",
                Password = "fhryr352",
                PhoneNumber = "+7(777)777-77-77",
                IsDeleted = false,
                Role = Enums.Role.Client,
                Rank = 4.5666,
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
                        Cleaners = new List<User> { } 
                    } 
                },
                CleanerOrders = new List<Order> { 
                    new Order { 
                        Address = "Арктическая 7, кв 23", 
                        Cleaners = new List<User> { } 
                    } 
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
                            Orders = new List<Order> 
                            { new Order { 
                                Address = "Арктическая 7, кв 23", 
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
                },
                new User
                {
                    Email = "BulgakovLove@mail.com",
                    FirstName = "Роман",
                    LastName = "Булгаков",
                    Login = "AnnushkinoMaslo",
                    Password = "2398764525",
                    PhoneNumber = "+7(921)8746325",
                    IsDeleted = false,
                    Role = Enums.Role.Client,
                    Rank = 4.5666,
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
                            Orders = new List<Order>
                            { new Order {
                                Address = "Арктическая 7, кв 23",
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
                },
                new User
                {
                    Email = "daryadarya@mail.com",
                    FirstName = "Дарья",
                    LastName = "Юдашкина",
                    Login = "Udashhhka",
                    Password = "blablabla",
                    PhoneNumber = "+78126543524",
                    IsDeleted = true,
                    Role = Enums.Role.Cleaner,
                    Rank = 4.5666,
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
                            Orders = new List<Order>
                            { new Order {
                                Address = "Арктическая 7, кв 23",
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
                }
            };

            return users;
        }
    }
}
