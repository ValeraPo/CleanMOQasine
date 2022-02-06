namespace CleanMOQasine.Data.Entities
{
    public class CleaningType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Order>? Order { get; set; }
        public virtual ICollection<CleaningAddition>? CleaningAdditions { get; set; }
        public bool IsDeleted { get; set; }
    }
}
