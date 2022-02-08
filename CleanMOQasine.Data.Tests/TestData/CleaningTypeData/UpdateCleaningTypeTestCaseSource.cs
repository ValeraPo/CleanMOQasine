using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData.CleaningTypeData
{
    public class UpdateCleaningTypeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            CleaningType entity1 = new CleaningType
            {
                Name = "Помыть лукавое окно",
                Price = 666,
                IsDeleted = false
            };
            yield return new object[] { entity1 , 1};
            CleaningType entity2 = new CleaningType
            {
                Name = "Выйти в окно",
                Price = 0,
                IsDeleted = false
            };
            yield return new object[] { entity2, 2 };
            CleaningType entity3 = new CleaningType
            {
                Name = "Повесить [имя]",
                Price = 234440,
                IsDeleted = false
            };
            yield return new object[] { entity3, 3 };
        }
    }
}
