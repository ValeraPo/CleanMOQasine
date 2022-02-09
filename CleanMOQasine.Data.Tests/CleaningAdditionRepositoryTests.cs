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
    public class CleaningAdditionRepositoryTests
    {
        private CleanMOQasineContext _context;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
               .UseInMemoryDatabase(databaseName: "Test1")
               .Options;
            var testData = new CleaningAdditionTestData();
            _context = new CleanMOQasineContext(opt);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Test]
        public void GetAllCleaningAdditionsTest()
        {
            //given
            var expected = _context.CleaningAdditions.Where(ca => !ca.IsDeleted);
            //when
            var repo = new CleaningAdditionRepository(_context);
            var actual = repo.GetAllCleaningAdditions();
            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void GetCleaningAdditionByIdTest(int id)
        {
            //given
            var expected = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);
            //when
            var repo = new CleaningAdditionRepository(_context);
            var actual = repo.GetCleaningAdditionById(id);
            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void AddCleaningAdditionTest(int entityNumber)
        {
            //given
            var entity = CleaningAdditionTestData.GetCleaningAdditionForTest(entityNumber);
            //when
            var repo = new CleaningAdditionRepository(_context);
            var id = repo.AddCleaningAddition(entity);
            _context.SaveChanges();
            var expected = _context.CleaningAdditions.FirstOrDefault(entity => entity.Id == id);
            //then
            Assert.True(id != 0);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected, entity);
        }

        [TestCase(1, 1)]
        [TestCase(2, 4)]
        [TestCase(3, 2)]
        public void UpdateCleaningAdditionTest(int entityNumber, int id)
        {
            //given
            var entityUpdated = CleaningAdditionTestData.GetCleaningAdditionForTest(entityNumber);
            var entity = _context.CleaningAdditions.FirstOrDefault(entity => entity.Id == id);
            
            //when
            var repo = new CleaningAdditionRepository(_context);
            repo.UpdateCleaningAddition(id, entityUpdated);

            //then
            Assert.AreEqual(entity.Name, entityUpdated.Name);
            Assert.AreEqual(entity.Price, entityUpdated.Price);
            Assert.AreEqual(entity.Duration, entityUpdated.Duration);
            Assert.AreNotEqual(entity, entityUpdated);
            Assert.True(_context.CleaningAdditions.Contains(entity));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteCleaningAdditionTest(int id)
        {
            //given
            var repo = new CleaningAdditionRepository(_context);
            var entity = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);

            //when
            entity.IsDeleted = false;
            repo.DeleteCleaningAddition(id);
            bool expected = entity.IsDeleted;

            //then
            Assert.True(expected);
            Assert.True(_context.CleaningAdditions.Contains(entity));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void RestoreCleaningAdditionTest(int id)
        {
            //given
            var repo = new CleaningAdditionRepository(_context);
            var entity = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);

            //when
            entity.IsDeleted = true;
            _context.SaveChanges();
            repo.RestoreCleaningAddition(id);
            bool expected = entity.IsDeleted;

            //then
            Assert.False(expected);
            Assert.True(_context.CleaningAdditions.Contains(entity));
        }

    }
}