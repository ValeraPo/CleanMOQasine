using CleanMOQasine.API.Models.Outputs;

namespace CleanMOQasine.API.Models
{
    public class OrderOutputModel
    {
        public int Id { get; set; }
        public int IdClient { get; set; }//а здесь скорее всего будет что-то типа UserOutputModel
        public int IdCleaningType { get; set; }
        public int IdGrade  { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TotalDuration { get; set; }//nado ne nada
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public virtual ICollection<int> IdRooms { get; set; }
        public virtual ICollection<CleaningAdditionOutputModel> CleaningAdditions { get; set; }   
        public virtual ICollection<int> IdCleaners { get; set; }
        public virtual ICollection<int> IdPayments { get; set; }
    }
}