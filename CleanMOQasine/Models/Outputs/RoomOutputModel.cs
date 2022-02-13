namespace CleanMOQasine.API.Models
{
    public class RoomOutputModel : RoomInputModel
    {
        public int Id { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
    }
}
