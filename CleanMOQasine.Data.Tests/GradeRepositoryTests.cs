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
using CleanMOQasine.Data.Tests.TestData;

namespace CleanMOQasine.Data.Tests
{
    public class GradeRepositoryTests
    {
        private CleanMOQasineContext _context;
        private Mock<IGradeRepository> mock = new Mock<IGradeRepository>();
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
            mock.Setup(obj => obj.GetAllGrades()).Returns(grades);
            foreach (var grade in grades)
                _context.Grade.Add(grade);
            _context.SaveChanges();
            var repo = new GradeRepository(_context);
            var actual = repo.GetAllGrades().ToList();
            var expected = _context.Grade.Where(g => !g.IsDeleted).ToList();
            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
            if (expected.Count != actual.Count)
                Assert.Fail();
        }

        [TestCaseSource(typeof(UpdateGradeTestCaseSource))]
        public void UpdateGradeAndDeleteGradeTest(Grade oldGrade, Grade updatedGrade, int id)
        {
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
}
