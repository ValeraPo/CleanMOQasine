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
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CleanMOQasine.Business.Tests.ServiceTests
{
    public class GradeServiceTests
    {
        private Mock<IGradeRepository> _gradeRepositoryMock;
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
        }

        [Test]
        public void GetGradeById()
        {
            //given
            var grade = _gradeTestData.GetGrade();
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns(grade);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);
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
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);

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
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);

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
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.UpdateGrade(new GradeModel(), It.IsAny<int>()));
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.UpdateGradeById(new Grade()), Times.Never());
        }

        [Test]
        public void GetAllGrades()
        {
            //given
            var grades = _gradeTestData.GetGrades();
            _gradeRepositoryMock.Setup(m => m.GetAllGrades()).Returns(grades);
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);

            //when
            var actual = sut.GetAllGrades();

            //then
            _gradeRepositoryMock.Verify(m => m.GetAllGrades(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual[0] is GradeModel);
        }

        [Test]
        public void DeleteGradeById()
        {
            //given
            _gradeRepositoryMock.Setup(m => m.GetGradeById(It.IsAny<int>())).Returns(new Grade());
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);

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
            var sut = new GradeService(_gradeRepositoryMock.Object, _autoMapper);

            //then
            Assert.Throws<NotFoundException>(() => sut.DeleteGradeById(It.IsAny<int>()));
            _gradeRepositoryMock.Verify(m => m.GetGradeById(It.IsAny<int>()), Times.Once());
            _gradeRepositoryMock.Verify(m => m.DeleteGradeById(It.IsAny<int>()), Times.Never());
        }
    }
}
