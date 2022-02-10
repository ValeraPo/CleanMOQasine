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
        private ICleaningAdditionRepository _repository;

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
            _repository = new CleaningAdditionRepository(_context);
        }

        [Test]
        public void GetAllCleaningAdditionsTest()
        {
            //given
            var expected = _context.CleaningAdditions.Where(ca => !ca.IsDeleted);

            //when
            var actual = _repository.GetAllCleaningAdditions();

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
            var expected = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id && !ca.IsDeleted);
            
            //when
            var actual = _repository.GetCleaningAdditionById(id);
            
            //then
            Assert.IsNotNull(actual);
            Assert.False(actual.IsDeleted);
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
            var id = _repository.AddCleaningAddition(entity);
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
            bool isDeletedBeforeUpdate = entity.IsDeleted;
            
            //when
            _repository.UpdateCleaningAddition(id, entityUpdated);

            //then
            Assert.AreEqual(entity.Name, entityUpdated.Name);
            Assert.AreEqual(entity.Price, entityUpdated.Price);
            Assert.AreEqual(entity.Duration, entityUpdated.Duration);
            Assert.AreEqual(isDeletedBeforeUpdate,entity.IsDeleted);
            Assert.AreNotEqual(entity, entityUpdated);
            Assert.True(_context.CleaningAdditions.Contains(entity));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteCleaningAdditionTest(int id)
        {
            //given
            var entity = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);

            //when
            entity.IsDeleted = false;
            _repository.DeleteCleaningAddition(id);
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
            var entity = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);

            //when
            entity.IsDeleted = true;
            _context.SaveChanges();
            _repository.RestoreCleaningAddition(id);
            bool expected = entity.IsDeleted;

            //then
            Assert.False(expected);
            Assert.True(_context.CleaningAdditions.Contains(entity));
        }

    }
}