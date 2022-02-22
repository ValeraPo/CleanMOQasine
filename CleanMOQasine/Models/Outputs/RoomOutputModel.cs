namespace CleanMOQasine.API.Models
{
    public class RoomOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
    }
}
