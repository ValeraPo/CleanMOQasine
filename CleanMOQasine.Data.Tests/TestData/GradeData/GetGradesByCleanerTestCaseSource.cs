using CleanMOQasine.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class GetGradesByCleanerTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var User1 = new User { Id = 1, Email = "1", Login = "1", Password = "1" };
            var User2 = new User { Id = 2, Email = "2", Login = "2", Password = "2" };
            var User3 = new User { Id = 3, Email = "3", Login = "3", Password = "3" };
            var User4 = new User { Id = 4, Email = "4", Login = "4", Password = "4" };
            var User5 = new User { Id = 5, Email = "5", Login = "5", Password = "5" };
            var User6 = new User { Id = 6, Email = "6", Login = "6", Password = "6" };
            var User7 = new User { Id = 7, Email = "7", Login = "7", Password = "7" };
            var User8 = new User { Id = 8, Email = "8", Login = "8", Password = "8" };
            Grade grade1 = new Grade
            {
                IsAnonymous = false,
                Comment = "grade1",
                Rating = 5,
                IsDeleted = false,
                Order = new Order
                {
                    CleaningType = new CleaningType { Name = "suka", Price = 23 },
                    Client = new User { Id = 11, Email = "11", Login = "11", Password = "11" },
                    Date = DateTime.Now,
                    Address = "aaaa",
                    Cleaners = new List<User> { User1, User4, User8 }
                }
            };
            Grade grade2 = new Grade
            {
                IsAnonymous = false,
                Comment = "grade2",
                Rating = 2,
                IsDeleted = false,
                Order = new Order
                {
                    CleaningType = new CleaningType { Name = "neSuka", Price=23 },
                    Client = new User { Id = 12, Email = "8", Login = "8", Password = "8" },
                    Date = DateTime.Now,
                    Address = "aaaa",
                    Cleaners = new List<User> { User6, User4, User5 }
                }
            };
            Grade grade3 = new Grade
            {
                IsAnonymous = true,
                Comment = "grade3",
                Rating = 3,
                IsDeleted = false,
                Order = new Order
                {
                    CleaningType = new CleaningType { Name = "suUUUka", Price = 23 },
                    Client = new User { Id = 13, Email = "8", Login = "8", Password = "8" },
                    Date = DateTime.Now,
                    Address = "aaaa",
                    Cleaners = new List<User> { User8, User7, User3 }
                }
            };
            Grade grade4 = new Grade
            {
                IsAnonymous = true,
                Comment = "grade4",
                Rating = 6,
                IsDeleted = false,
                Order = new Order
                {
                    CleaningType = new CleaningType { Name = "sukcca", Price = 23 },
                    Client = new User { Id = 14, Email = "8", Login = "8", Password = "8" },
                    Date = DateTime.Now,
                    Address = "aaaa",
                    Cleaners = new List<User> { User1, User4, User2 }
                }
            };
            Grade grade5 = new Grade
            {
                IsAnonymous = true,
                Comment = "grade5",
                Rating = 3,
                IsDeleted = false,
                Order = new Order
                {
                    CleaningType = new CleaningType { Name = "suka4", Price = 23 },
                    Client = new User { Id = 15, Email = "8", Login = "8", Password = "8" },
                    Date = DateTime.Now,
                    Address = "aaaa",
                    Cleaners = new List<User> { User8, User3 }
                }
            };
            List<Grade> grades = new();
            grades.Add(grade1);
            grades.Add(grade2);
            grades.Add(grade3);
            grades.Add(grade4);
            grades.Add(grade5);
            yield return new object[] { grades, 1, new List<Grade> { grade1, grade4 } };
            yield return new object[] { grades, 8, new List<Grade> { grade1, grade3, grade5 } };
            yield return new object[] { grades, 7, new List<Grade> { grade3 } };
            yield return new object[] { grades, 228, new List<Grade> () };
        }
    }
}
