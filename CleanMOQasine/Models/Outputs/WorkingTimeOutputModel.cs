namespace CleanMOQasine.API.Models
{
    public class WorkingTimeOutputModel 
    {
        public UserOutputModel User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Day { get; set; }
    }
}
