namespace CleanMOQasine.API.Models
{
    public class OrderUpdateInputModel
    {
        public int CleaningTypeId { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public List<int> RoomIds { get; set; }
        public List<CleaningAdditionInputModel> CleaningAdditions { get; set; }
    }
}