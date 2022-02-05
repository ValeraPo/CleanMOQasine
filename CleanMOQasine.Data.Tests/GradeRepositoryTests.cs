using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Moq;
using System.Linq;

namespace CleanMOQasine.Data.Tests
{
    public class GradeRepositoryTests
    {
        private CleanMOQasineContext _context;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _context = new CleanMOQasineContext(opt); 
        }

        [TestCaseSource(typeof(GetGradeByIdTestCaseSource))]
        public void GetGradeByIdTest(Grade grade, int id)
        {
            Mock<IGradeRepository> mock = new Mock<IGradeRepository>();
            mock.Setup(obj => obj.GetGradeById(id)).Returns(grade);
            _context.Grade.Add(grade);
            _context.SaveChanges();
            var repo = new GradeRepository(_context);
            var actual = repo.GetGradeById(id);
            var expected = _context.Grade.FirstOrDefault(g => g.Id == id);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllGradesTestCaseSource))]
        public void GetAllGradesTest(List <Grade> grades)
        {
            Mock<IGradeRepository> mock = new Mock<IGradeRepository>();
            mock.Setup(obj => obj.GetAllGrades()).Returns(grades);
            foreach (var grade in grades)
            {
                _context.Grade.Add(grade);
                _context.SaveChanges();
            }
            var repo = new GradeRepository(_context);
            var actual = repo.GetAllGrades().ToList();
            var expected = _context.Grade.Where(g => !g.IsDeleted).ToList();
            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestCaseSource(typeof(UpdateGradeTestCaseSource))]
        public void UpdateGradeAndDeleteGradeTest(Grade oldGrade, Grade updatedGrade, int id)
        {
            Mock<IGradeRepository> mock = new Mock<IGradeRepository>();
            mock.Setup(obj => obj.UpdateGradeById(updatedGrade));
            var repo = new GradeRepository(_context);
            _context.Grade.Add(oldGrade);
            _context.SaveChanges();
            repo.UpdateGradeById(updatedGrade);
            var actual = _context.Grade.FirstOrDefault(g => g.Id == id);
            var expected = updatedGrade;
            Assert.AreEqual(expected, actual);
            actual.IsDeleted = true;
            _context.SaveChanges();
            actual = _context.Grade.FirstOrDefault(g => g.Id == id);
            if (!actual.IsDeleted)
                Assert.Fail();
        }
    }

    public class GetGradeByIdTestCaseSource : IEnumerable
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
                OrderId = 1
            };
            int id1 = 1;
            yield return new object[] { grade1, id1 };
            Grade grade2 = new Grade
            {
                Id = 2,
                IsAnonymous = false,
                Comment = "NeOk",
                Rating = 2,
                IsDeleted = false,
                OrderId = 1
            };
            int id2 = 2;
            yield return new object[] { grade2, id2 };
        }
    }

    public class GetAllGradesTestCaseSource : IEnumerable
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
                OrderId = 1
            };
            Grade grade2 = new Grade
            {
                Id = 2,
                IsAnonymous = false,
                Comment = "NeOk",
                Rating = 2,
                IsDeleted = false,
                OrderId = 2
            };
            Grade grade3 = new Grade
            {
                Id = 3,
                IsAnonymous = true,
                Comment = "Ne",
                Rating = 3,
                IsDeleted = false,
                OrderId = 3
            };
            List<Grade> grades = new();
            grades.Add(grade1);
            grades.Add(grade2);
            grades.Add(grade3);
            yield return new object[] { grades};
        }
    }

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
                OrderId = 1
            };
            Grade updatedGrade = new Grade
            {
                Id = 1,
                IsAnonymous = true,
                Comment = "lol",
                Rating = 5,
                IsDeleted = false,
                OrderId = 1
            };
            yield return new object[] { oldGrade, updatedGrade, 1 };
        }
    }
}
