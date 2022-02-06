using CleanMOQasine.Data.Enums;
namespace CleanMOQasine.Data.Entities
{
    public class WorkingTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public WeekDay Day { get; set; }
        public virtual User? User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
