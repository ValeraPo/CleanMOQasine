namespace CleanMOQasine.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public User Client { get; set; }
        public CleaningType CleaningType { get; set; }
        public List<CleaningAddition> CleaningAdditions { get; set; }
        public List<User> Cleaners { get; set; }
        public List<Payment> Payments { get; set; }
        public Grade Grade { get; set; }
        public List<Room> Rooms { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
