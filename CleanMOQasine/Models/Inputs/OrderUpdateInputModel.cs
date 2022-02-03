using CleanMOQasine.API.Models.Inputs;

namespace CleanMOQasine.API.Models
{
    public class OrderUpdateInputModel
    {
        public int IdCleaningType { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public  ICollection<int> IdRooms { get; set; }
        public  ICollection<CleaningAdditionInputModel> CleaningAdditions { get; set; }
    }
}