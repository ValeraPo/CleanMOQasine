using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData.CleaningTypeData
{
    public class CleaningTypeTestData
    {
        public CleaningType GetCleaningTypeForTest()
        {
            CleaningType cleaningType = new CleaningType
            {
                Id = 666,
                Name = "Похоронная",
                Price = 777,
                CleaningAdditions = new List<CleaningAddition>
                {
                    new CleaningAddition
                    {
                        Id = 101,
                        Name = "УБрать венки",
                        Duration = new TimeSpan(0,30,0),
                        Price=1000
                    },
                    new CleaningAddition
                    {
                        Id = 102,
                        Name = "Отмыть усопшего(-ую)",
                        Duration = new TimeSpan(0,40,0),
                        Price = 3000
                    },
                    new CleaningAddition
                    {
                        Id = 104,
                        Name = "УБрать лоток за питомцем",
                        Duration = new TimeSpan(0,6,0),
                        Price = 80
                    },
                    new CleaningAddition
                    {
                        Id = 103,
                        Name = "Выкопать яму для могилы",
                        Duration = new TimeSpan(1,30,0),
                        Price = 1500
                    }
                    
                }
            };
            return cleaningType;
        }

        public List<CleaningType> GetCleaningTypesForTest()
        {
            List<CleaningType> cleaningTypesSeed = new();

            cleaningTypesSeed.Add(new CleaningType() { Id = 1, Name = "Поддерживающая", Price = 3000, IsDeleted = false });
            cleaningTypesSeed.Add(new CleaningType() { Id = 2, Name = "Генеральная", Price = 6000, IsDeleted = false });
            cleaningTypesSeed.Add(new CleaningType() { Id = 3, Name = "После ремонта", Price = 8000, IsDeleted = false });
            cleaningTypesSeed.Add(new CleaningType() { Id = 4, Name = "Мытье окон", Price = 2000, IsDeleted = false });

            return cleaningTypesSeed;
        }
    }
}
