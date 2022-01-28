namespace CleanMOQasine.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public virtual User Client { get; set; }
        public virtual CleaningType CleaningType { get; set; }
        public virtual ICollection<CleaningAddition> CleaningAdditions { get; set; }
        public virtual ICollection<User> Cleaners { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TotalDuration { get; set; }//nado ne nada
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
