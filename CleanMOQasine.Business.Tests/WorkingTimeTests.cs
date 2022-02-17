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

        public WorkingTimeTests()
        {
            _workingTimeRepositoryMock = new Mock<IWorkingTimeRepository>();
            _mapper = new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperToData>()));
        }


        [TestCaseSource(typeof(WorkingTimesTestCaseSources)
            , nameof(WorkingTimesTestCaseSources.GetAllWorkingTimes))]
        public void GetAllWorkingTimesTests(List<WorkingTimeModel> expected, List<WorkingTime> workingTimes)
        {
            _workingTimeRepositoryMock.Setup(m => m.GetAllWorkingTimes()).Returns(workingTimes);
            var workingTimeService = new WorkingTimeService(_workingTimeRepositoryMock.Object, _mapper);
            var actual = workingTimeService.GetAllWorkingTimes();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
