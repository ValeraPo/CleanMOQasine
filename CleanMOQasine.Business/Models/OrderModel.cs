
namespace CleanMOQasine.Business.Models
{
    public class OrderModel
    {
        private decimal _totalPrice;
        private TimeSpan _totalDuration;
        private bool _isCompleted;

        public int Id { get; set; }
        public UserModel Client { get; set; }
        public CleaningTypeModel CleaningType { get; set; }
        public GradeModel Grade { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice 
        {
            get
            {
                _totalPrice = (CleaningType.CleaningAdditions.Select(c => c.Price).Sum()
                + CleaningAdditions.Select(c => c.Price).Sum()) * Rooms.Count
                + Rooms.Select(r => r.Price).Sum();
                return _totalPrice;
            }
            set { } 
        }

        public TimeSpan TotalDuration
        {
            get
            {
                foreach (var c in CleaningType.CleaningAdditions.Select(c => c.Duration))
                    _totalDuration += c;
                foreach (var c in CleaningAdditions.Select(c => c.Duration))
                    _totalDuration += c;
                _totalDuration *= Rooms.Count;
                return _totalDuration;
            }
            set { }
        }

        public DateTime Date { get; set; }
        public bool IsCompleted 
        {
            get => Date.Add(TotalDuration) <= DateTime.Now;
            
            set 
            {
                _isCompleted = value;
            } 
        }
        public bool IsDeleted { get; set; }

        public List<RoomModel> Rooms { get; set; }
        public List<CleaningAdditionModel> CleaningAdditions { get; set; }
        public List<UserModel> Cleaners { get; set; }
        public List<PaymentModel> Payments { get; set; }

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
