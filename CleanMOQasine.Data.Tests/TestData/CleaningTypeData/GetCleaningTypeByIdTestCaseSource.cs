using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData.CleaningTypeData
{
    internal class GetCleaningTypeByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            CleaningType entity1 = new CleaningType
            {
                Id = 189,
                Name = "Помыть лукавое окно",
                Price = 666,
                IsDeleted = false
            };
            yield return entity1;
            CleaningType entity2 = new CleaningType
            {
                Id = 228,
                Name = "Выйти в окно",
                Price = 0,
                IsDeleted = false
            };
            yield return entity2;
            CleaningType entity3 = new CleaningType
            {
                Id = 4568,
                Name = "Повесить [имя]",
                Price = 234440,
                IsDeleted = false
            };
            yield return entity3;
        }
    }
}
