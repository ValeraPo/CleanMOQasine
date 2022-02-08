using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class AddGradeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Grade grade = new Grade
            {
                Id = 3,
                IsAnonymous = false,
                Comment = "Ok",
                Rating = 5,
                IsDeleted = false,
            };
            Order order = new Order
            {
                Id = 1,
                Client = null,
                CleaningType = null,
                Address = "qwe",
                Date = DateTime.Now,
                IsDeleted = false
            };
            yield return new object[] { grade, order};
        }
    }
}
