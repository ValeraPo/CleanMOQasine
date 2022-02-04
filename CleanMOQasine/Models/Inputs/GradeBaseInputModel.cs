namespace CleanMOQasine.API.Models
{
    public class GradeBaseInputModel
    {
        public int Id { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
