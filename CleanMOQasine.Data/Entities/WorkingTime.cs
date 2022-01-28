namespace CleanMOQasine.Data.Entities
{
    public class WorkingTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek Day { get; set; }
        public User User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
