using CleanMOQasine.Data.Entities;
using System.Collections;

namespace CleanMOQasine.Data.Tests.TestData.CleaningTypeData
{
    public class AddCleaningTypeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            CleaningType entity1 = new CleaningType
            {
                Name = "Помыть лукавое окно",
                Price = 666,
                IsDeleted = false
            };
            yield return entity1;
            CleaningType entity2 = new CleaningType
            {
                Name = "Выйти в окно",
                Price = 0,
                IsDeleted = false
            };
            yield return entity2;
            CleaningType entity3 = new CleaningType
            {
                Name = "Повесить [имя]",
                Price = 234440,
                IsDeleted = false
            };
            yield return entity3;
        }
    }
}
