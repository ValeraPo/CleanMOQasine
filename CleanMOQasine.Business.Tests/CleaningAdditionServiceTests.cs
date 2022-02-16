﻿using AutoMapper;
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
    public class CleaningAdditionServiceTests
    {
        private readonly Mock<ICleaningAdditionRepository> _cleaningAdditionRepositoryMock;
        private readonly CleaningAdditionTestData _cleaningAdditionTestData;
        private readonly IMapper _autoMapper;

        public CleaningAdditionServiceTests()
        {
            _cleaningAdditionRepositoryMock = new Mock<ICleaningAdditionRepository>();
            _cleaningAdditionTestData = new CleaningAdditionTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [Test]
        public void GetCleaningAdditionById_ShouldReturnCleaningAdditionWithCertainId()
        {
            //given
            var cleaningAddition = _cleaningAdditionTestData.GetCleaningAdditionForTests();
            _cleaningAdditionRepositoryMock.Setup(x => x.GetCleaningAdditionById(It.IsAny<int>())).Returns(cleaningAddition);
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);
            var expected = _autoMapper.Map<CleaningAdditionModel>(cleaningAddition);

            //when
            var actual = sut.GetCleaningAdditionById(1);

            //then
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual.Id, expected.Id);
        }

        [Test]
        public void GetCleaningAdditionById_ShouldThrowNotFoundException()
        {
            //given
            _cleaningAdditionRepositoryMock.Setup(m => m.GetCleaningAdditionById(It.IsAny<int>())).Returns((CleaningAddition)null);
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.GetCleaningAdditionById(666));
        }

        [Test]
        public void GetAllCleaningAdditions_ShouldReturnCleaningAdditionModels()
        {
            //given
            var cleaningAdditions = _cleaningAdditionTestData.GetCleaningAdditionsForTests();
            _cleaningAdditionRepositoryMock.Setup(m => m.GetAllCleaningAdditions()).Returns(cleaningAdditions);
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            var actual = sut.GetAllCleaningAdditions();

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(CleaningAdditionModel), actual[0]);
        }


        [Test]
        public void AddCleaningAddition()
        {
            //given
            var cleaningAdditionModel = _cleaningAdditionTestData.GetCleaningAdditionModelForTests();
            _cleaningAdditionRepositoryMock.Setup(m => m.AddCleaningAddition(It.IsAny<CleaningAddition>())).Returns(23);
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.AddCleaningAddition(cleaningAdditionModel);

            //then
            _cleaningAdditionRepositoryMock.Verify(m => m.AddCleaningAddition(It.IsAny<CleaningAddition>()), Times.Once());
        }

        [Test]
        public void DeleteCleaningAddition()
        {
            //given
            var cleaningAddition = new CleaningAddition();
            _cleaningAdditionRepositoryMock.Setup(m => m.GetCleaningAdditionById(It.IsAny<int>())).Returns(cleaningAddition);
            _cleaningAdditionRepositoryMock.Setup(m => m.DeleteCleaningAddition(It.IsAny<int>()));
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.DeleteCleaningAddition(23);

            //then
            _cleaningAdditionRepositoryMock.Verify(m => m.GetCleaningAdditionById(It.IsAny<int>()), Times.Once());
            _cleaningAdditionRepositoryMock.Verify(m => m.DeleteCleaningAddition(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void DeleteCleaningAddition_ShouldThrowNotFoundException()
        {
            //given
            _cleaningAdditionRepositoryMock.Setup(m => m.GetCleaningAdditionById(It.IsAny<int>())).Returns((CleaningAddition)null);
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteCleaningAddition(5678));
        }

        [Test]
        public void UpdateCleaningAddition()
        {
            //given
            var cleaningAddition = new CleaningAddition();
            _cleaningAdditionRepositoryMock.Setup(m => m.GetCleaningAdditionById(It.IsAny<int>())).Returns(cleaningAddition);
            _cleaningAdditionRepositoryMock.Setup(m => m.UpdateCleaningAddition(It.IsAny<int>()));
            var sut = new CleaningAdditionService(_cleaningAdditionRepositoryMock.Object, _autoMapper);

            //when
            sut.DeleteCleaningAddition(23);

            //then
            _cleaningAdditionRepositoryMock.Verify(m => m.GetCleaningAdditionById(It.IsAny<int>()), Times.Once());
            _cleaningAdditionRepositoryMock.Verify(m => m.DeleteCleaningAddition(It.IsAny<int>()), Times.Once());
        }
    }
}
