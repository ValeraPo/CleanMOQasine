using CleanMOQasine.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class WorkingHoursTestCaseSources
    {
        public static IEnumerable<TestCaseData> GetAllWorkingHoursData()
        {
            WorkingTime workingTimeMock = new() 
            {
                Id = 1,
                Day = Enums.WeekDay.Monday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = false
            };
            WorkingTime workingTimeMock1 = new()
            {
                Id = 2,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = true
            };
            WorkingTime workingTimeMock2 = new()
            {
                Id = 3,
                Day = Enums.WeekDay.Saturday,
                EndTime = DateTime.Now.AddHours(5),
                IsDeleted = false
            };
            List<WorkingTime> allWorkingTimes = new();
            allWorkingTimes.Add(workingTimeMock);
            allWorkingTimes.Add(workingTimeMock1);
            allWorkingTimes.Add(workingTimeMock2);
            List<WorkingTime> expected = new();
            expected.Add(workingTimeMock);
            expected.Add(workingTimeMock2);
            yield return new TestCaseData(allWorkingTimes, expected);
        }

        public static IEnumerable<TestCaseData> GetWorkingTimeById()
        {
            WorkingTime workingTimeMock = new()
            {
                Id = 1,
                Day = Enums.WeekDay.Monday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = false
            };
            yield return new TestCaseData(workingTimeMock, workingTimeMock);
            WorkingTime workingTimeMock1 = new()
            {
                Id = 2,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(2),
                IsDeleted = true
            };
            yield return new TestCaseData(workingTimeMock1, null);
        }

        public static IEnumerable<TestCaseData> UpdateWorkingHours()
        {
            WorkingTime workingTimeMock = new()
            {
                Id = 1,
                Day = Enums.WeekDay.Monday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = false
            };
            WorkingTime updatedWorkingTimeMock = new()
            {
                Id = 1,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = true
            };
            yield return new TestCaseData(workingTimeMock, updatedWorkingTimeMock);
            WorkingTime workingTimeMock1 = new()
            {
                Id = 2,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(2),
                IsDeleted = false
            };
            WorkingTime updatedWorkingTimeMock1 = new()
            {
                Id = 2,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(1),
                IsDeleted = true
            };
            yield return new TestCaseData(workingTimeMock1, updatedWorkingTimeMock1);
        }

        public static IEnumerable<TestCaseData> DeleteWorkingTimeById()
        {
            WorkingTime workingTimeMock = new()
            {
                Id = 1,
                Day = Enums.WeekDay.Monday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = false
            };
            WorkingTime expected = new()
            {
                Id = 1,
                Day = Enums.WeekDay.Monday,
                EndTime = workingTimeMock.EndTime,
                IsDeleted = true
            };
            yield return new TestCaseData(workingTimeMock, expected);
            WorkingTime workingTimeMock1 = new()
            {
                Id = 2,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(2),
                IsDeleted = false
            };
            WorkingTime expected1 = new()
            {
                Id = 2,
                Day = Enums.WeekDay.Friday,
                EndTime = workingTimeMock1.EndTime,
                IsDeleted = true
            };
            yield return new TestCaseData(workingTimeMock1, expected1);
        }

        public static IEnumerable<TestCaseData> AddWorkingTime()
        {
            WorkingTime workingTimeMock = new()
            {
                Id = 4,
                Day = Enums.WeekDay.Monday,
                EndTime = DateTime.Now.AddHours(8),
                IsDeleted = false
            };
            yield return new TestCaseData(workingTimeMock, workingTimeMock);
            WorkingTime workingTimeMock1 = new()
            {
                Id = 5,
                Day = Enums.WeekDay.Friday,
                EndTime = DateTime.Now.AddHours(2),
                IsDeleted = false
            };
            yield return new TestCaseData(workingTimeMock1, workingTimeMock1);
        }
    }
}
