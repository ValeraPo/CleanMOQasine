using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class CleaningAdditionTestData
    {
        public static CleaningAddition GetCleaningAdditionForTest(int id)
        {
            return id switch
            {
                1 => new CleaningAddition()
                {
                    Price = 100,
                    Name = "Убрать грязь",
                    IsDeleted = false,
                    Duration = new TimeSpan(0, 30, 0)
                },
                2 => new CleaningAddition()
                {
                    Price = 1000,
                    Name = "Убрать",
                    IsDeleted = false,
                    Duration = new TimeSpan(10, 30, 0)
                },
                3 => new CleaningAddition()
                {
                    Price = 100,
                    Name = "Проветрить",
                    IsDeleted = false,
                    Duration = new TimeSpan(1, 0, 0)
                },
                _ => new CleaningAddition()
                {
                    Price = 500,
                    Name = "Помыть посуду",
                    IsDeleted = false,
                    Duration = new TimeSpan(1, 34, 0)
                },
            };
        }
    }
}
