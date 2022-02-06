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
    public class UserRepositoryTests
    {
        private CleanMOQasineContext _dbContext;
        private Mock<IUserRepository> fakeUserRepository = new Mock<IUserRepository>();

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _dbContext = new CleanMOQasineContext(opt);
        }

        [TestCaseSource(typeof(GetGradeByIdTestCaseSource))]
        public void GetGradeByIdTest(Grade grade)
        {
            //given
            mock.Setup(obj => obj.GetGradeById(grade.Id)).Returns(grade);
            _context.Grades.Add(grade);
            _context.SaveChanges();
            //when
            var repo = new GradeRepository(_context);
            var actual = repo.GetGradeById(grade.Id);
            var expected = _context.Grades.FirstOrDefault(g => g.Id == grade.Id);
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllGradesTestCaseSource))]
        public void GetAllGradesTest(List<Grade> grades, List<Grade> expectedList)
        {
            //given
            mock.Setup(obj => obj.GetAllGrades()).Returns(grades);
            foreach (var grade in grades)
                _context.Grades.Add(grade);
            _context.SaveChanges();
            //when
            var repo = new GradeRepository(_context);
            var actual = repo.GetAllGrades().ToList();
            var expected = expectedList;
            //then
            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
            if (expected.Count != actual.Count)
                Assert.Fail();
        }

        [TestCaseSource(typeof(UpdateGradeTestCaseSource))]
        public void UpdateGradeAndDeleteGradeTest(Grade oldGrade, Grade updatedGrade, int id)
        {
            //given
            mock.Setup(obj => obj.UpdateGradeById(updatedGrade));
            var repo = new GradeRepository(_context);
            _context.Grades.Add(oldGrade);
            _context.SaveChanges();
            repo.UpdateGradeById(updatedGrade);
            //when
            var actual = _context.Grades.FirstOrDefault(g => g.Id == id);
            var expected = updatedGrade;
            //then
            Assert.AreEqual(expected, actual);
            actual.IsDeleted = true;
            _context.SaveChanges();
            actual = _context.Grades.FirstOrDefault(g => g.Id == id);
        }

        [TestCaseSource(typeof(DeleteGradeById))]
        public void DeleteGradeById(List<Grade> grades, List<Grade> expected, int idToDelete)
        {
            //given
            mock.Setup(obj => obj.DeleteGradeById(idToDelete));
            var repo = new GradeRepository(_context);
            foreach (var grade in grades)
                _context.Grades.Add(grade);
            _context.SaveChanges();
            //when
            repo.DeleteGradeById(idToDelete);
            List<Grade> actual = _context.Grades.Where(g => !g.IsDeleted).ToList();
            //then
            if (actual.Count != expected.Count)
                Assert.Fail();
            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
