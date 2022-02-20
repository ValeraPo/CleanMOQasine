using CleanMOQasine.Data.Enums;

namespace CleanMOQasine.Business.Models
{
    public class WorkingTimeModel
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public WeekDay Day { get; set; }
    }
}
