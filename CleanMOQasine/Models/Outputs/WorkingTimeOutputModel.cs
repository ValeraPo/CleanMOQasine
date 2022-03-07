namespace CleanMOQasine.API.Models
{
    public class WorkingTimeOutputModel 
    {
        public int UserId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Day { get; set; }
    }
}
