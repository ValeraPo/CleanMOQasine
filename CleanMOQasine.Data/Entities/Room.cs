namespace CleanMOQasine.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}
