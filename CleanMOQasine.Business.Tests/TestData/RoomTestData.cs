using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class RoomTestData
    {
        public RoomModel GetRoomModelForTests()
        {
            RoomModel room = new RoomModel
            {
                Id = 1,
                Name = "Чердак",
                Price = 1000,
                IsDeleted = false,
            };

            return room;
        }

        public Room GetRoomForTests()
        {
            Room room = new Room
            {
                Name = "Чердак",
                Price = 1000,
                IsDeleted = false,
                Orders = new List<Order> {
                    new Order {
                        Address = "Бакалейная ул 16, кв 101",
                        Cleaners = new List<User> {
                            new User {
                                FirstName = "Гриша",
                                LastName = "Бровкин",
                                IsDeleted = false,
                                Email = "nothinInterestin@mail.ru",
                                Login = "brovkin",
                                Password = "greatPassword",
                                PhoneNumber = "89217653425"
                            },
                            new User {
                                FirstName = "Гоша",
                                LastName = "Куценко",
                                IsDeleted = false,
                                Email = "cleanclean@mail.ru",
                                Login = "KucKuc",
                                Password = "cleverPassword",
                                PhoneNumber = "89217653634"
                            }
                        },
                        Client = new User {
                            FirstName = "Мария",
                            LastName = "Куценко",
                            IsDeleted = false,
                            Email = "ahYes@mail.ru",
                            Login = "tratata",
                            Password = "anotherCleverPassword",
                            PhoneNumber = "89817654635"
                        },
                        IsDeleted = false,
                        Date = DateTime.Now
                    }
                }
            };

            return room;
        }

        public List<Room> GetListOfRoomsForTests()
        {
            List<Room> rooms = new List<Room> {
                new Room {
                    Name = "Чердак",
                    Price = 1000,
                    IsDeleted = false,
                    Orders = new List<Order> {
                        new Order {
                            Address = "Бакалейная ул 16, кв 101",
                            Cleaners = new List<User> {
                                new User {
                                    FirstName = "Гриша",
                                    LastName = "Бровкин",
                                    IsDeleted = false,
                                    Email = "nothinInterestin@mail.ru",
                                    Login = "brovkin",
                                    Password = "greatPassword",
                                    PhoneNumber = "89217653425"
                                },
                                new User {
                                    FirstName = "Гоша",
                                    LastName = "Куценко",
                                    IsDeleted = false,
                                    Email = "cleanclean@mail.ru",
                                    Login = "KucKuc",
                                    Password = "cleverPassword",
                                    PhoneNumber = "89217653634"
                                }
                            },
                            Client = new User {
                                FirstName = "Мария",
                                LastName = "Куценко",
                                IsDeleted = false,
                                Email = "ahYes@mail.ru",
                                Login = "tratata",
                                Password = "anotherCleverPassword",
                                PhoneNumber = "89817654635"
                            },
                            IsDeleted = false,
                            Date = DateTime.Now
                        }
                    }

                },
                new Room {
                    Name = "Спальня",
                    Price = 800,
                    IsDeleted = true,
                    Orders = new List<Order> {
                        new Order {
                            Address = "Бакалейная ул 16, кв 101",
                            Cleaners = new List<User> {
                                new User {
                                    FirstName = "Гриша",
                                    LastName = "Бровкин",
                                    IsDeleted = false,
                                    Email = "nothinInterestin@mail.ru",
                                    Login = "brovkin",
                                    Password = "greatPassword",
                                    PhoneNumber = "89217653425"
                                },
                                new User {
                                    FirstName = "Гоша",
                                    LastName = "Куценко",
                                    IsDeleted = false,
                                    Email = "cleanclean@mail.ru",
                                    Login = "KucKuc",
                                    Password = "cleverPassword",
                                    PhoneNumber = "89217653634"
                                }
                            },
                            Client = new User {
                                FirstName = "Мария",
                                LastName = "Куценко",
                                IsDeleted = false,
                                Email = "ahYes@mail.ru",
                                Login = "tratata",
                                Password = "anotherCleverPassword",
                                PhoneNumber = "89817654635"
                            },
                            IsDeleted = false,
                            Date = DateTime.Now
                        }
                    }
                }
            };

            return rooms;
        }
    }
}
