using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests
{
    public class WorkingHoursTests
    {
        private CleanMOQasineContext _context;
        private IWorkingTimeRepository _repo;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<CleanMOQasineContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _context = new CleanMOQasineContext(opt);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repo = new WorkingTimeRepository(_context);
        }

        [TestCaseSource(typeof(WorkingHoursTestCaseSources)
            , nameof(WorkingHoursTestCaseSources.GetAllWorkingHoursData))]
        public void GetAllWorkingTimesTests(List<WorkingTime> allWorkingHours
            , List<WorkingTime> expected)
        {
            //given
            _context.WorkingHours.AddRange(allWorkingHours);
            _context.SaveChanges();

            //when
            var actual = _repo.GetAllWorkingTimes();

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(WorkingHoursTestCaseSources)
            , nameof(WorkingHoursTestCaseSources.GetWorkingTimeById))]
        public void GetWorkingTimeByIdTests(WorkingTime workingHours
            , WorkingTime expected)
        {
            //given
            _context.WorkingHours.Add(workingHours);
            _context.SaveChanges();

            //when
            var actual = _repo.GetWorkingTimeById(workingHours.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(WorkingHoursTestCaseSources)
            , nameof(WorkingHoursTestCaseSources.UpdateWorkingHours))]
        public void UpdateWorkingTimeByIdTests(WorkingTime workingHours
            , WorkingTime expected)
        {
            //given
            _context.WorkingHours.Add(workingHours);
            _context.SaveChanges();

            //when
            _repo.UpdateWorkingTime(expected);
            var actual = _context.WorkingHours.FirstOrDefault(w => w.Id == workingHours.Id);

            //then
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }

        [TestCaseSource(typeof(WorkingHoursTestCaseSources)
            , nameof(WorkingHoursTestCaseSources.DeleteWorkingTimeById))]
        public void DeleteWorkingTimeByIdTests(WorkingTime workingHours
            , WorkingTime expected)
        {
            //given
            _context.WorkingHours.Add(workingHours);
            _context.SaveChanges();

            //when
            _repo.DeleteWorkingTime(workingHours.Id);
            var actual = _context.WorkingHours.FirstOrDefault(w => w.Id == workingHours.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(WorkingHoursTestCaseSources)
            , nameof(WorkingHoursTestCaseSources.AddWorkingTime))]
        public void AddWorkingTime(WorkingTime workingHours
            , WorkingTime expected)
        {
            //given
            UserTestData mockedUser = new();
            var user = mockedUser.GetUserForTests();
            _context.Users.Add(user);
            _context.SaveChanges();

            //when
            _repo.AddWorkingTime(workingHours, user);
            var actual = _context.WorkingHours.FirstOrDefault(w => w.Id == workingHours.Id);

            //then
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(user.Id, actual.User.Id);
        }
    }
}
