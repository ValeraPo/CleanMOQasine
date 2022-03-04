using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Business.Tests.TestData;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests
{
    public class WorkingTimeTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkingTimeRepository> _workingTimeRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public WorkingTimeTests()
        {
            _workingTimeRepositoryMock = new Mock<IWorkingTimeRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }


        [TestCaseSource(typeof(WorkingTimesTestCaseSources)
            , nameof(WorkingTimesTestCaseSources.GetAllWorkingTimes))]
        public void GetAllWorkingTimesTests(List<WorkingTimeModel> expected, List<WorkingTime> workingTimes)
        {
            //given
            _workingTimeRepositoryMock.Setup(m => m.GetAllWorkingTimes()).Returns(workingTimes);
            var workingTimeService = new WorkingTimeService(_workingTimeRepositoryMock.Object, _userRepositoryMock.Object, _mapper);
            
            //when
            var actual = workingTimeService.GetAllWorkingTimes();

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(WorkingTimesTestCaseSources)
            , nameof(WorkingTimesTestCaseSources.GetWorkingTimeById))]
        public void GetWorkingTimeByIdTests(WorkingTimeModel expected, WorkingTime workingTime)
        {
            //given
            _workingTimeRepositoryMock.Setup(m => m.GetWorkingTimeById(workingTime.Id)).Returns(workingTime);
            var workingTimeService = new WorkingTimeService(_workingTimeRepositoryMock.Object, _userRepositoryMock.Object, _mapper);

            //when
            var actual = workingTimeService.GetWorkingTimeById(workingTime.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(WorkingTimesTestCaseSources)
            , nameof(WorkingTimesTestCaseSources.UpdateWorkingTime))]
        public void UpdateWorkingTimeTests(WorkingTimeModel expected, WorkingTime workingTime)
        {
            //given
            _workingTimeRepositoryMock.Setup(m => m.GetWorkingTimeById(workingTime.Id)).Returns(workingTime);
            _workingTimeRepositoryMock.Setup(m => m.UpdateWorkingTime(workingTime));
            var workingTimeService = new WorkingTimeService(_workingTimeRepositoryMock.Object, _userRepositoryMock.Object, _mapper);

            //when
            workingTimeService.UpdateWorkingTime(new WorkingTimeModel(), workingTime.Id);

            //then
            _workingTimeRepositoryMock.Verify(m => m.GetWorkingTimeById(It.IsAny<int>()), Times.Once());
            _workingTimeRepositoryMock.Verify(m => m.UpdateWorkingTime(It.IsAny<WorkingTime>()), Times.Once());
        }

        [TestCase(1)]
        public void DeleteWorkingTimeTests(int id)
        {
            //given
            _workingTimeRepositoryMock.Setup(m => m.GetWorkingTimeById(id)).Returns(new WorkingTime() { Id = 1});
            _workingTimeRepositoryMock.Setup(m => m.DeleteWorkingTime(id));
            var workingTimeService = new WorkingTimeService(_workingTimeRepositoryMock.Object, _userRepositoryMock.Object, _mapper);

            //when
            workingTimeService.DeleteWorkingTimeById(id);

            //then
            _workingTimeRepositoryMock.Verify(m => m.GetWorkingTimeById(It.IsAny<int>()), Times.Once());
            _workingTimeRepositoryMock.Verify(m => m.DeleteWorkingTime(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void AddWorkingTime()
        {

        }
    }
}
