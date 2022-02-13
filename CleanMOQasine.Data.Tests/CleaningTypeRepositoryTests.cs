using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData.CleaningTypeData;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CleanMOQasine.Data.Tests
{
    public class CleaningTypeRepositoryTests
    {
        private CleanMOQasineContext _context;
        private Mock<ICleaningTypeRepository> mock = new Mock<ICleaningTypeRepository>();
        private ICleaningTypeRepository _repository;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
               .UseInMemoryDatabase(databaseName: "Test1")
               .Options;
            _context = new CleanMOQasineContext(opt);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repository = new CleaningTypeRepository(_context);
        }

        [TestCaseSource(typeof(GetCleaningTypeByIdTestCaseSource))]
        public void GetCleaningTypeByIdTest(CleaningType cleaningType)
        {
            //given
            mock.Setup(obj => obj.GetCleaningTypeById(cleaningType.Id)).Returns(cleaningType);
            _context.CleaningTypes.Add(cleaningType);

            //when
            var actual = _repository.GetCleaningTypeById(cleaningType.Id);
            var expected = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == cleaningType.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllCleaningTypesTest()
        {
            //given
            var expected = GetEntitiesForGetAllCleaningTypesTest();

            //when
            var actual = _repository.GetAllCleaningTypes();

            //then
            CollectionAssert.AreEqual(actual, actual);
        }

        [TestCaseSource(typeof(AddCleaningTypeTestCaseSource))]
        public void AddCleaningTypeTest(CleaningType cleaningTypeAdd)
        {
            //given
            int oldLength = _context.CleaningTypes.Count();

            //when
            int id = _repository.AddCleaningType(cleaningTypeAdd);
            var expectedCleaningTypeAdd = _context.CleaningTypes.FirstOrDefault(ecta => ecta.Id == id);
            int expectedLength = _context.CleaningTypes.Count();

            //then
            Assert.AreEqual(cleaningTypeAdd, expectedCleaningTypeAdd);
            Assert.AreEqual(oldLength + 1, expectedLength);
        }

        [TestCaseSource(typeof(UpdateCleaningTypeTestCaseSource))]
        public void UpdateCleaningTypeTest(CleaningType cleaningTypeUpdate, int id)
        {
            //given
            var oldCleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == id);

            //when
            bool resultUpdated = _repository.UpdateCleaningType(id, cleaningTypeUpdate);
            var newCleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == id);

            //then
            Assert.True(resultUpdated);
            Assert.AreEqual(newCleaningType, oldCleaningType);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void DeleteCleaningTypeTest(int id)
        {
            //given
            var cleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == id);
            bool isDeletedFalse = cleaningType.IsDeleted;

            //when
            _repository.DeleteCleaningType(id);
            var deletedCleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == id);

            //then
            Assert.AreNotEqual(deletedCleaningType.IsDeleted, isDeletedFalse);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void RestoreCleaningTypeTest(int id)
        {
            //given
            var cleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == id);
            cleaningType.IsDeleted = true;

            //when
            _repository.RestoreCleaningType(id);
            var restoredCleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == id);

            //then
            Assert.AreEqual(restoredCleaningType.IsDeleted, false);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void AddCleaningAdditionToCleaningTypeTest(int cleaningTypeId, int cleaningAdditionId)
        {
            //given
            var cleaningAddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == cleaningAdditionId);

            //when
            _repository.AddCleaningAdditionToCleaningType(cleaningTypeId, cleaningAdditionId);
            var cleaningType = _context.CleaningTypes.FirstOrDefault(ct => ct.Id == cleaningTypeId);

            //then
            Assert.True(cleaningType.CleaningAdditions.Contains(cleaningAddition));
        }

        public List<CleaningType> GetEntitiesForGetAllCleaningTypesTest()
        {
            List<CleaningType> cleaningTypesSeed = new();

            cleaningTypesSeed.Add(new CleaningType() { Id = 1, Name = "Поддерживающая", Price = 3000, IsDeleted = false });
            cleaningTypesSeed.Add(new CleaningType() { Id = 2, Name = "Генеральная", Price = 6000, IsDeleted = false });
            cleaningTypesSeed.Add(new CleaningType() { Id = 3, Name = "После ремонта", Price = 8000, IsDeleted = false });
            cleaningTypesSeed.Add(new CleaningType() { Id = 4, Name = "Мытье окон", Price = 2000, IsDeleted = false });

            return cleaningTypesSeed;
        }
    }
}