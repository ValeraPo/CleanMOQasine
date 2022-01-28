namespace CleanMOQasine.Data.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
    }
}
