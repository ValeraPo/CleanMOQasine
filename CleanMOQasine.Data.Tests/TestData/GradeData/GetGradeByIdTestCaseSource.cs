using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class GetGradeByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Grade grade1 = new Grade
            {
                IsAnonymous = false,
                Comment = "Ok",
                Rating = 5,
                IsDeleted = false,
            };
            yield return new object[] { grade1};
            Grade grade2 = new Grade
            {
                IsAnonymous = false,
                Comment = "NeOk",
                Rating = 2,
                IsDeleted = false,
            };
            yield return new object[] { grade2};
        }
    }
}
