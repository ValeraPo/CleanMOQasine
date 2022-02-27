using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests.TestData
{
    public class WorkingTimesTestCaseSources
    {

        public static IEnumerable<TestCaseData> GetAllWorkingTimes()
        {
            WorkingTimeModel workingTimeModel = new()
            {
                Day = 1,
                StartTime = TimeOnly.FromDateTime(DateTime.Now),
                EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(8))
            };
            WorkingTimeModel workingTimeModel1 = new()
            {
                Day = 2,
                StartTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(2)),
                EndTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(2).AddHours(6))
            };
            WorkingTimeModel workingTimeModel2 = new()
            {
                Day = 3,
                StartTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(3)),
                EndTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(3).AddHours(3))
            };
            List<WorkingTimeModel> workingTimeModels = new();
            workingTimeModels.Add(workingTimeModel);
            workingTimeModels.Add(workingTimeModel1);
            workingTimeModels.Add(workingTimeModel2);
            WorkingTime workingTime = new()
            {
                Id = 1,
                Day = Data.Enums.WeekDay.Monday,
                StartTime = workingTimeModel.StartTime,
                EndTime = workingTimeModel.EndTime,
                IsDeleted = false
            };
            WorkingTime workingTime1 = new()
            {
                Id = 2,
                Day = Data.Enums.WeekDay.Tuesday,
                StartTime = workingTimeModel1.StartTime,
                EndTime = workingTimeModel1.EndTime,
                IsDeleted = false
            };
            WorkingTime workingTime2 = new()
            {
                Id = 3,
                Day = Data.Enums.WeekDay.Wednesday,
                StartTime = workingTimeModel2.StartTime,
                EndTime = workingTimeModel2.EndTime,
                IsDeleted = false
            };
            List<WorkingTime> workingTimes = new();
            workingTimes.Add(workingTime);
            workingTimes.Add(workingTime1);
            workingTimes.Add(workingTime2);
            yield return new TestCaseData(workingTimeModels, workingTimes);
        }

        public static IEnumerable<TestCaseData> GetWorkingTimeById()
        {
            WorkingTimeModel workingTimeModel = new()
            {
                Day = 1,
                StartTime = TimeOnly.FromDateTime(DateTime.Now),
                EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(8))
            };
            WorkingTime workingTime = new()
            {
                Id = 1,
                Day = Data.Enums.WeekDay.Monday,
                StartTime = workingTimeModel.StartTime,
                EndTime = workingTimeModel.EndTime,
                IsDeleted = false
            };
            yield return new TestCaseData(workingTimeModel, workingTime);
        }

        public static IEnumerable<TestCaseData> UpdateWorkingTime()
        {
            WorkingTimeModel workingTimeModel = new()
            {
                Day = 1,
                StartTime = TimeOnly.FromDateTime(DateTime.Now),
                EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(8))
            };
            WorkingTime workingTime = new()
            {
                Id = 1,
                Day = Data.Enums.WeekDay.Monday,
                StartTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                EndTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(-2).AddHours(3))
            };
            yield return new TestCaseData(workingTimeModel, workingTime);
        }
    }
}
