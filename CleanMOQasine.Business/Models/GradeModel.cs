using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Business.Models
{
    public class GradeModel
    {
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
        public Order Order { get; set; }
    }
}
