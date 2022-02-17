using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class CleaningTypeTestData
    {
        public CleaningTypeModel GetCleaningTypeModelForTests()
        {
            CleaningTypeModel room = new CleaningTypeModel
            {
                Id = 1,
                Name = "Убрать трупы",
                Price = 1000,
                CleaningAdditions = new List<CleaningAdditionModel>
                {
                    new CleaningAdditionModel
                    {
                        Name = "Смыть кровь",
                        Price = 1000,
                        Duration = new TimeSpan(1,1,1)
                    },
                    new CleaningAdditionModel
                    {
                        Name = "Помыть ножи",
                        Price = 300,
                        Duration = new TimeSpan(0,10,1)
                    },
                    new CleaningAdditionModel
                    {
                        Name = "Упаковать нарезку в пакеты)))",
                        Price = 10000,
                        Duration = new TimeSpan(1,0,0)
                    },
                }
            };

            return room;
        }

        public CleaningType GetCleaningTypeForTests()
        {
            CleaningType cleaningType = new CleaningType
            {
                Id = 1,
                Name = "Убрать трупы",
                Price = 1000,
                IsDeleted = false,
                CleaningAdditions = new List<CleaningAddition>
                {
                    new CleaningAddition
                    {
                        Name = "Смыть кровь",
                        Price = 1000,
                        Duration = new TimeSpan(1,1,1)
                    },
                    new CleaningAddition
                    {
                        Name = "Помыть ножи",
                        Price = 300,
                        Duration = new TimeSpan(0,10,1)
                    },
                    new CleaningAddition
                    {
                        Name = "Упаковать нарезку в пакеты)))",
                        Price = 10000,
                        Duration = new TimeSpan(1,0,0)
                    },
                }
            };

            return cleaningType;
        }

        public List<CleaningType> GetListOCleaningTypesForTests()
        {
            List<CleaningType> rooms = new List<CleaningType> 
            {
                new CleaningType 
                {
                    Name = "Кайфовая",
                    Price = 1000,
                    IsDeleted = false,
                },
                new CleaningType 
                {
                    Name = "Вечная",
                    Price = 800,
                    IsDeleted = true,    
                }
            };

            return rooms;
        }
    }
}
