using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class UpdateGradeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Grade oldGrade = new Grade
            {
                Id = 1,
                IsAnonymous = false,
                Comment = "Ok",
                Rating = 5,
                IsDeleted = false,
            };
            Grade updatedGrade = new Grade
            {
                Id = 1,
                IsAnonymous = true,
                Comment = "lol",
                Rating = 5,
                IsDeleted = false,
            };
            yield return new object[] { oldGrade, updatedGrade, 1 };
        }
    }
}
