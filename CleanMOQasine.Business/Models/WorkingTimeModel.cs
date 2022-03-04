namespace CleanMOQasine.Business.Models
{
    public class WorkingTimeModel
    {
        public int Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int Day { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not WorkingTimeModel)
                return false;
            var toEqual = (WorkingTimeModel)obj;
            return StartTime == toEqual.StartTime
                && EndTime == toEqual.EndTime
                && Day == toEqual.Day;
        }
    }
}
