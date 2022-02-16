using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class CleaningAdditionTestData
    {
        public CleaningAdditionModel GetCleaningAdditionModelForTests()
        {
            CleaningAdditionModel cleaningAdditionModel = new CleaningAdditionModel
            {
                Id = 1,
                Name = "Уборка",
                Price = 3000,
                Duration = new TimeSpan(1, 0, 0),
                IsDeleted = false
            };
            return cleaningAdditionModel;
        }

        public CleaningAddition GetCleaningAdditionForTests()
        {
            CleaningAddition cleaningAddition = new CleaningAddition
            {
                Id = 1,
                Name = "Уборка",
                Price = 3000,
                Duration = new TimeSpan(1, 0, 0),
                IsDeleted = false
            };
            return cleaningAddition;
        }

        public List<CleaningAddition> GetCleaningAdditionsForTests()
        {
            CleaningAddition cleaningAddition1 = new CleaningAddition
            {
                Id = 1,
                Name = "Уборка",
                Price = 3000,
                Duration = new TimeSpan(1, 0, 0),
                IsDeleted = false
            };
            CleaningAddition cleaningAddition2 = new CleaningAddition
            {
                Id = 2,
                Name = "Уборка2222",
                Price = 6000,
                Duration = new TimeSpan(2222, 0, 0),
                IsDeleted = false
            };
            CleaningAddition cleaningAddition3 = new CleaningAddition
            {
                Id = 3,
                Name = "Уборка по цене как в барвихе, а так тоже самое",
                Price = 439000,
                Duration = new TimeSpan(1, 0, 0),
                IsDeleted = false
            };

            List<CleaningAddition> cleaningAdditions = new List<CleaningAddition>();
            cleaningAdditions.Add(cleaningAddition1);
            cleaningAdditions.Add(cleaningAddition2);
            cleaningAdditions.Add(cleaningAddition3);
            return cleaningAdditions;
        }
    }
}
