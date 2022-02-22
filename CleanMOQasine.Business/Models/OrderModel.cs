using CleanMOQasine.Business.Extensions;

namespace CleanMOQasine.Business.Models
{
    public class OrderModel
    {
        private bool _isCompleted;

        public int Id { get; set; }
        public UserModel Client { get; set; }
        public CleaningTypeModel CleaningType { get; set; }
        public GradeModel Grade { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public List<RoomModel> Rooms { get; set; }
        public List<CleaningAdditionModel> CleaningAdditions { get; set; }
        public List<UserModel> Cleaners { get; set; }
        public List<PaymentModel> Payments { get; set; }
        public bool IsDeleted { get; set; }

        public decimal TotalPrice 
        {
            get => (CleaningType.CleaningAdditions.Select(c => c.Price).Sum()
                + CleaningAdditions.Select(c => c.Price).Sum()) * Rooms.Count
                + Rooms.Select(r => r.Price).Sum();
            
            set { } 
        }

        public TimeSpan TotalDuration
        {
            get => (CleaningType.CleaningAdditions.Select(c => c.Duration).Sum()
                + CleaningAdditions.Select(c => c.Duration).Sum())
                * Rooms.Count;
           
            set { }
        }

        public bool IsCompleted 
        {
            get => Date.Add(TotalDuration) <= DateTime.Now;
            
            set 
            {
                _isCompleted = value;
            } 
        }

        private bool Equals(OrderModel order)
        {
            return order.Client.FirstName.Equals(Client.FirstName)
                && order.Client.LastName.Equals(Client.LastName)
                && order.Client.Login.Equals(Client.Login)
                && order.CleaningType.Name.Equals(CleaningType.Name)
                && order.Address.Equals(Address)
                && order.Date.Equals(Date)
                && order.IsDeleted.Equals(IsDeleted)
                && order.IsCompleted.Equals(IsCompleted)
                && order.TotalDuration.Equals(TotalDuration)
                && order.TotalPrice.Equals(TotalPrice)
                && order.Rooms.Select(r => r.Name).SequenceEqual<string>(Rooms.Select(r => r.Name))
                && order.CleaningAdditions.Select(r => r.Name).SequenceEqual<string>(CleaningAdditions.Select(r => r.Name))
                && order.Cleaners.Select(r => r.Login).SequenceEqual<string>(Cleaners.Select(r => r.Login))
                && order.Payments.Select(r => r.Amount).SequenceEqual<decimal>(Payments.Select(r => r.Amount));
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return obj.GetType() == GetType() && Equals((OrderModel)obj);
        }
    }
}
