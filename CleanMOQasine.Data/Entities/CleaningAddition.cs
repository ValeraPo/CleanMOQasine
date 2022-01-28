namespace CleanMOQasine.Data.Entities
{
    public class CleaningAddition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
        public CleaningType CleaningType { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
