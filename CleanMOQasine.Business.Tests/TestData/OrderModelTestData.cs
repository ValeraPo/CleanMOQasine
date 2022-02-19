using CleanMOQasine.Business.Models;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class OrderModelTestData
    {
        public OrderModel GetOrderModelForTests()
        {
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
        }
    }
}
