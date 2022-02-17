namespace CleanMOQasine.Business.Models
{
    public class WorkingTimeModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
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
