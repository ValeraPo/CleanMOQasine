using CleanMOQasine.API.Models.Outputs;

namespace CleanMOQasine.API.Models
{
    public class OrderOutputModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }//а здесь скорее всего будет что-то типа UserOutputModel
        public int CleaningTypeId { get; set; }
        public int GradeId  { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TotalDuration { get; set; }//nado ne nada
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public List<int> RoomIds { get; set; }
        public List<CleaningAdditionOutputModel> CleaningAdditions { get; set; }   
        public List<int> CleanerIds { get; set; }
        public List<int> PaymentIds { get; set; }
    }
}