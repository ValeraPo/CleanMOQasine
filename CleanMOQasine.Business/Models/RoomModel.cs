using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Business.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual List<Order> Orders { get; set; }
        public bool IsDeleted { get; set; }
    }
}
