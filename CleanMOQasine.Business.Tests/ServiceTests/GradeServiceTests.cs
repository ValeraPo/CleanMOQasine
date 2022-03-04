using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CleanMOQasine.Business.Tests.ServiceTests
{
    public class GradeServiceTests
    {
        private Mock<IGradeRepository> _gradeRepositoryMock;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private readonly GradeServiceTestData _gradeTestData;
        private readonly IMapper _autoMapper;

        public GradeServiceTests()
        {
            _gradeTestData = new GradeServiceTestData();
            _autoMapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }

        [SetUp]
        public void Setup()
        {
            _gradeRepositoryMock = new Mock<IGradeRepository>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Test]
        public void GetGradeById()
        {
            //given
            var grade = _gradeTestData.GetGrade();
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns(grade);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);
            var expected = _autoMapper.Map<GradeModel>(grade);
            //when
            var actual = sut.GetGradeById(It.IsAny<int>());

            //then
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            Assert.AreEqual(expected, actual);  
        }

        [Test]
        public void GetGradeById_ShouldReturnNotFoundException()
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns((Grade)null);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.GetGradeById(It.IsAny<int>()));
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void UpdateGrade()
        {
            //given
            var grade = _gradeTestData.GetGrade();
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns(grade);
            _gradeRepositoryMock.Setup(m => m.UpdateGradeById(grade));
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //when
            sut.UpdateGrade(new GradeModel(), It.IsAny<int>());

            //then
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.UpdateGradeById(new Grade()), Times.Once());

        }

        [Test]
        public void UpdateGrade_ShouldReturnNotFoundException()
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns((Grade)null);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.UpdateGrade(new GradeModel(), It.IsAny<int>()));
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.UpdateGradeById(new Grade()), Times.Never());
        }

        [TestCaseSource(typeof(GradeServiceTestData), nameof(GradeServiceTestData.GetGrades))]
        public void GetAllGrades(List<Grade> grades)
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetAllGrades()).Returns(grades);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //when
            var actual = sut.GetAllGrades();

            //then
            _gradeRepositoryMock.Verify(m => m.GetAllGrades(), Times.Once());
            Assert.True(actual is List<GradeModel>);
        }

        [Test]
        public void DeleteGradeById()
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns(new Grade());
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //when
            sut.DeleteGradeById(It.IsAny<int>());

            //then
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.DeleteGradeById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void DeleteGradeById_ShouldReturnNotFoundException()
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns((Grade)null);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteGradeById(It.IsAny<int>()));
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.DeleteGradeById(It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void AddGrade()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns(new Order());
            _gradeRepositoryMock.Setup(m => m.AddGrade(new Grade(), It.IsAny<int>()));
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //when
            sut.AddGrade(new GradeModel(), It.IsAny<int>());

            //then
            _orderRepositoryMock.Verify(m => m.GetOrderById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.AddGrade(new Grade(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void AddGrade_ShouldReturnOrderNotFoundException()
        {
            //given
            _orderRepositoryMock.Setup(m => m.GetOrderById(It.IsAny<int>())).Returns((Order)null);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => sut.AddGrade(new GradeModel(), It.IsAny<int>()));
            _orderRepositoryMock.Verify(m => m.GetOrderById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.AddGrade(new Grade(), It.IsAny<int>()), Times.Never());
        }

        [TestCaseSource(typeof(GradeServiceTestData), nameof(GradeServiceTestData.GetGrades))]
        public void GetAllGradesByCleanerId(List<Grade> grades)
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetGradesByCleaner(It.IsAny<int>())).Returns(grades);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper, _orderRepositoryMock.Object, _userRepositoryMock.Object);

            //when
            var actual = sut.GetAllGradesByCleanerId(It.IsAny<int>());

            //then
            _gradeRepositoryMock.Verify(m => m.GetGradesByCleaner(It.IsAny<int>()), Times.Once());
            Assert.True(actual is List<GradeModel>);
        }
    }
}
