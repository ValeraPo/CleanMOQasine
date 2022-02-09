namespace CleanMOQasine.Business.Models
{
    public class GradeModel
    {
        public int Id { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
        public OrderModel Order { get; set; }
    }
}
