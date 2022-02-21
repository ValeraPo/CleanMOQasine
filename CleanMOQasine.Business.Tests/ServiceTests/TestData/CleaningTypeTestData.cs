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
            CleaningTypeModel сleaningType = new CleaningTypeModel
            {
                Id = 1,
                Name = "После резни",
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
                        Name = "Убрать свидетеля",
                        Price = 1000000,
                        Duration = new TimeSpan(1,10,1)
                    },
                    new CleaningAdditionModel
                    {
                        Name = "Упаковать нарезку в пакеты",
                        Price = 10000,
                        Duration = new TimeSpan(1,0,0)
                    },
                }
            };

            return сleaningType;
        }

        public CleaningType GetCleaningTypeForTests()
        {
            CleaningType cleaningType = new CleaningType
            {
                Id = 1,
                Name = "После резни",
                Price = 1000,
                IsDeleted = false,
                CleaningAdditions = new List<CleaningAddition>
                {
                    new CleaningAddition
                    {
                        Id=1,
                        Name = "Смыть кровь",
                        Price = 1000,
                        Duration = new TimeSpan(1,1,1)
                    },
                    new CleaningAddition
                    {
                        Id = 2,
                        Name = "Убрать свидетеля",
                        Price = 1000000,
                        Duration = new TimeSpan(1,10,1)
                    },
                    new CleaningAddition
                    {
                        Id = 3,
                        Name = "Упаковать нарезку в пакеты",
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
                    Name = "Грязная",
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

        public CleaningAddition GetCleaningAdditionForTest()
        {
            return new CleaningAddition
            {
                Name = "Вылизать унитаз",
                Price= 1000,
                Duration = new TimeSpan(0,20,0)
            };
        }
    }
}
