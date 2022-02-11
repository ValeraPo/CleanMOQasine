using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class DeleteGradeById : IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            Grade grade1 = new Grade
            {
                Id = 1,
                IsAnonymous = false,
                Comment = "Ok",
                Rating = 5,
                IsDeleted = false,
            };
            Grade grade2 = new Grade
            {
                Id = 2,
                IsAnonymous = false,
                Comment = "NeOk",
                Rating = 2,
                IsDeleted = false,
            };
            Grade grade3 = new Grade
            {
                Id = 3,
                IsAnonymous = true,
                Comment = "Ne",
                Rating = 3,
                IsDeleted = false,
            };
            Grade grade4 = new Grade
            {
                Id = 4,
                IsAnonymous = true,
                Comment = "Ne",
                Rating = 6,
                IsDeleted = false,
            };
            List<Grade> grades = new();
            grades.Add(grade1);
            grades.Add(grade2);
            grades.Add(grade3);
            grades.Add(grade4);
            var expectedList = new List<Grade>();
            expectedList.Add(grade1);
            expectedList.Add(grade2);
            expectedList.Add(grade3);
            yield return new object[] { grades, expectedList, grade4.Id };
        }
    }
}
