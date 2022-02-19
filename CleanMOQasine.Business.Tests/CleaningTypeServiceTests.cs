using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Exceptions;
using CleanMOQasine.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace CleanMOQasine.Business.Tests
{
    public class CleaningTypeServiceTests
    {
        private Mock<ICleaningTypeRepository> _cleaningTypeRepositoryMock;
        private Mock<ICleaningAdditionRepository> _cleaningAdditionRepositoryMock;
        private CleaningTypeTestData _cleaningTypeTestData;
        private IMapper _autoMapper;

        [SetUp]
        public void Setup()
        {
            _cleaningTypeRepositoryMock = new Mock<ICleaningTypeRepository>();
            _cleaningAdditionRepositoryMock = new Mock<ICleaningAdditionRepository>();
            _cleaningTypeTestData = new CleaningTypeTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [Test]
        public void GetCleaningTypeById_ShouldReturnCleaningTypeWithCleaningAdditions()
        {
            //given
            var cleaningType = _cleaningTypeTestData.GetCleaningTypeForTests();
            _cleaningTypeRepositoryMock.Setup(x => x.GetCleaningTypeById(It.IsAny<int>())).Returns(cleaningType);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);
            var expected = _autoMapper.Map<CleaningTypeModel>(cleaningType);

            //when
            var actual = sut.GetCleaningTypeById(1);

            //then
            Assert.AreEqual(actual, expected);
            CollectionAssert.AreEqual(actual.CleaningAdditions, expected.CleaningAdditions);
            Assert.NotNull(actual.CleaningAdditions);
            Assert.IsTrue(actual.CleaningAdditions.Count > 0);
            Assert.NotNull(actual.CleaningAdditions[0]);
        }

        [Test]
        public void GetCleaningTypeById_ShouldThrowNotFoundException()
        {
            //given
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns((CleaningType)null);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.GetCleaningTypeById(It.IsAny<int>()));
        }

        [Test]
        public void GetAllCleaningTypes_ShouldReturnCleaningTypes()
        {
            //given
            var cleaningTypes = _cleaningTypeTestData.GetListOCleaningTypesForTests();
            _cleaningTypeRepositoryMock.Setup(m => m.GetAllCleaningTypes()).Returns(cleaningTypes);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            var actual = sut.GetAllCleaningTypes();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
        }

        [Test]
        public void AddCleaningType()
        {
            //given
            var cleaningType = _cleaningTypeTestData.GetCleaningTypeModelForTests();
            _cleaningTypeRepositoryMock.Setup(m => m.AddCleaningType(It.IsAny<CleaningType>())).Returns((It.IsAny<int>()));
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.AddCleaningType(cleaningType);

            //then
            _cleaningTypeRepositoryMock.Verify(m => m.AddCleaningType(It.IsAny<CleaningType>()), Times.Once());
        }

        [Test]
        public void AddCleaningAdditionToCleaningType()
        {
            //given
            var cleaningType = _cleaningTypeTestData.GetCleaningTypeForTests();
            var cleaningAddition = _cleaningTypeTestData.GetCleaningAdditionForTest();
            _cleaningTypeRepositoryMock.Setup(x => x.GetCleaningTypeById(It.IsAny<int>())).Returns(cleaningType);
            _cleaningAdditionRepositoryMock.Setup(x => x.GetCleaningAdditionById(It.IsAny<int>())).Returns(cleaningAddition);
            _cleaningTypeRepositoryMock.Setup(x => x.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>()));
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>());

            //then
            _cleaningTypeRepositoryMock.Verify(m => m.GetCleaningTypeById(It.IsAny<int>()), Times.Once());
            _cleaningAdditionRepositoryMock.Verify(m => m.GetCleaningAdditionById(It.IsAny<int>()), Times.Once());
            _cleaningTypeRepositoryMock.Verify(m => m.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void AddCleaningAdditionToCleaningType_ShouldThrowNotFoundCleaningTypeException()
        {
            //given
            _cleaningTypeRepositoryMock.Setup(x => x.GetCleaningTypeById(It.IsAny<int>())).Returns((CleaningType)null);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>()));
            _cleaningTypeRepositoryMock.Verify(m => m.GetCleaningTypeById(It.IsAny<int>()), Times.Once());
            _cleaningAdditionRepositoryMock.Verify(m => m.GetCleaningAdditionById(It.IsAny<int>()), Times.Never());
            _cleaningTypeRepositoryMock.Verify(m => m.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void AddCleaningAdditionToCleaningType_ShouldThrowNotFoundCleaningAdditionException()
        {
            //given
            var cleaningType = _cleaningTypeTestData.GetCleaningTypeForTests();
            _cleaningTypeRepositoryMock.Setup(x => x.GetCleaningTypeById(It.IsAny<int>())).Returns(cleaningType);
            _cleaningAdditionRepositoryMock.Setup(x => x.GetCleaningAdditionById(It.IsAny<int>())).Returns((CleaningAddition)null);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>()));
            _cleaningTypeRepositoryMock.Verify(m => m.GetCleaningTypeById(It.IsAny<int>()), Times.Once());
            _cleaningAdditionRepositoryMock.Verify(m => m.GetCleaningAdditionById(It.IsAny<int>()), Times.Once());
            _cleaningTypeRepositoryMock.Verify(m => m.AddCleaningAdditionToCleaningType(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void UpdateCleaningType()
        {
            //given
            var cleaningType = new CleaningType();
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns(cleaningType);
            _cleaningTypeRepositoryMock.Setup(m => m.UpdateCleaningType(It.IsAny<int>(),cleaningType));
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.UpdateCleaningType(It.IsAny<int>(), new CleaningTypeModel());

            //then
            _cleaningTypeRepositoryMock.Verify(m => m.GetCleaningTypeById(It.IsAny<int>()), Times.Once());
            _cleaningTypeRepositoryMock.Verify(m => m.UpdateCleaningType(It.IsAny<int>(), cleaningType), Times.Once());
        }

        [Test]
        public void UpdateCleaningType_ShouldThrowNotFoundException()
        {
            //given
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns((CleaningType)null);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.UpdateCleaningType(It.IsAny<int>(), new CleaningTypeModel()));
        }

        [Test]
        public void DeleteCleaningType()
        {
            //given
            var cleaningType = new CleaningType();
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns(cleaningType);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.DeleteCleaningType(It.IsAny<int>());

            //then
            _cleaningTypeRepositoryMock.Verify(m => m.GetCleaningTypeById(It.IsAny<int>()), Times.Once());
            _cleaningTypeRepositoryMock.Verify(m => m.DeleteCleaningType(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void DeleteCleaningType_ShouldThrowNotFoundException()
        {
            //given
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns((CleaningType)null);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteCleaningType(It.IsAny<int>()));
        }

        [Test]
        public void RestoreCleaningType()
        {
            //given
            var cleaningType = new CleaningType();
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns(cleaningType);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.RestoreCleaningType(It.IsAny<int>());

            //then
            _cleaningTypeRepositoryMock.Verify(m => m.GetCleaningTypeById(It.IsAny<int>()), Times.Once());
            _cleaningTypeRepositoryMock.Verify(m => m.RestoreCleaningType(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void RestoreCleaningType_ShouldThrowNotFoundException()
        {
            //given
            _cleaningTypeRepositoryMock.Setup(m => m.GetCleaningTypeById(It.IsAny<int>())).Returns((CleaningType)null);
            var sut = new CleaningTypeService(_cleaningTypeRepositoryMock.Object, _cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.RestoreCleaningType(It.IsAny<int>()));
        }
    }
}
