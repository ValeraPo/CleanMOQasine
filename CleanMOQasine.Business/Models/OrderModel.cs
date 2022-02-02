
namespace CleanMOQasine.Business.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        //public UserModel Client { get; set; }
        //public CleaningTypeModel CleaningType { get; set; }
        //public GradeModel Grade { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }


        //public ICollection<RoomModel> Rooms { get; set; }
        //public ICollection<CleaningAdditionModel> CleaningAdditions { get; set; }
        //public ICollection<UserModel> Cleaners { get; set; }
        //public ICollection<PaymentModel> Payments { get; set; }
    }
}
