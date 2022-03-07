using CleanMOQasine.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMOQasine.Data.Entities
{
    public class WorkingTime
    {
        public int Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public WeekDay Day { get; set; }
        public virtual User? User { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not WorkingTime)
                return false;
            var workingTime = (WorkingTime)obj;
            return Id == workingTime.Id
                && StartTime == workingTime.StartTime
                && EndTime == workingTime.EndTime
                && Day == workingTime.Day
                && IsDeleted == workingTime.IsDeleted;
        }
    }
}
