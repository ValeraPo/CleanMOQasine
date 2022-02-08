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

        public override bool Equals(object? obj)
        {
            return obj is CleaningType type &&
                   Id == type.Id &&
                   Name == type.Name &&
                   Price == type.Price &&
                   //EqualityComparer<ICollection<Order>?>.Default.Equals(Order, type.Order) &&
                   //EqualityComparer<ICollection<CleaningAddition>?>.Default.Equals(CleaningAdditions, type.CleaningAdditions) &&
                   IsDeleted == type.IsDeleted;
        }
    }
}
