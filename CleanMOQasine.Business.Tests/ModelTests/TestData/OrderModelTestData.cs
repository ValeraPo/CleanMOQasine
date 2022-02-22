using CleanMOQasine.Business.Models;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class OrderModelTestData
    {
        public OrderModel MockInputOrderModel(int orderNumber)
        {
            switch (orderNumber)
            {
                case 1:
                    return new OrderModel
                    {
                        Date = new DateTime(2125, 12, 25),
                        CleaningType = new CleaningTypeModel
                        {
                            CleaningAdditions = new List<CleaningAdditionModel>()
                        {
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromMinutes(0),
                            Price = 0
                        },
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromHours(0),
                            Price = 0
                        }
                        }
                        },
                        CleaningAdditions = new List<CleaningAdditionModel>()
                        {
                            new CleaningAdditionModel {Duration = TimeSpan.FromDays(0)},
                            new CleaningAdditionModel {Duration = TimeSpan.FromSeconds(0)}
                        },
                        Rooms = new List<RoomModel>()
                        {
                            new RoomModel {Price = 0},
                            new RoomModel {Price = 0},
                            new RoomModel {Price = 0},
                        }
                    };
                case 2:
                    return new OrderModel
                    {
                        Date = new DateTime(2015, 12, 25),
                        CleaningType = new CleaningTypeModel
                        {
                            CleaningAdditions = new List<CleaningAdditionModel>()
                        {
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromMinutes(20),
                            Price = 300
                        },
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromHours(1),
                            Price = 500
                        }
                        }
                        },
                        CleaningAdditions = new List<CleaningAdditionModel>()
                        {
                            new CleaningAdditionModel {Duration = TimeSpan.FromDays(0.5)},
                            new CleaningAdditionModel {Duration = TimeSpan.FromSeconds(500)}
                        },
                        Rooms = new List<RoomModel>()
                        {
                            new RoomModel {Price = 100},
                            new RoomModel {Price = 200},
                            new RoomModel {Price = 5},
                        }
                    };
                case 3:
                    return new OrderModel
                    {
                        Date = DateTime.Now,
                        CleaningType = new CleaningTypeModel
                        {
                            CleaningAdditions = new List<CleaningAdditionModel>()
                        {
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromHours(20),
                            Price = (decimal)1.75
                        },
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromHours(1),
                            Price = (decimal)300.567
                        },
                        new CleaningAdditionModel
                        {
                            Duration = TimeSpan.FromHours(2),
                            Price = (decimal)0.54828
                        }
                        }
                        },
                        CleaningAdditions = new List<CleaningAdditionModel>()
                        {
                            new CleaningAdditionModel {Duration = TimeSpan.FromDays(2)},
                            new CleaningAdditionModel {Duration = TimeSpan.FromDays(1)}
                        },
                        Rooms = new List<RoomModel>()
                        {
                            new RoomModel {Price = (decimal)9.43878},
                            new RoomModel {Price = (decimal)789.98797},
                            new RoomModel {Price = (decimal)4.5939333},
                        }
                    };
                default: throw new Exception("Неверные входные данные");
            }

        }

        public TimeSpan MockOutpuTotalDuration(int orderNumber)
        {
            switch (orderNumber)
            {
                case 1:
                    return new TimeSpan(0);
                case 2:
                    return new TimeSpan(1, 16, 25, 0);
                case 3:
                    return new TimeSpan(11, 21, 0, 0);
                default: throw new Exception("Неверные входные данные");
            }
        }
    }
}
