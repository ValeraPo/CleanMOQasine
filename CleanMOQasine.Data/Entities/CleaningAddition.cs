namespace CleanMOQasine.Data.Entities
{
    public class CleaningAddition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual CleaningType CleaningType { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsDeleted { get; set; }
    }
}
