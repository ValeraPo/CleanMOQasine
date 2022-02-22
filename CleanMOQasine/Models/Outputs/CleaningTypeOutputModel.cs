namespace CleanMOQasine.API.Models
{
    public class CleaningTypeOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderOutputModel> Order { get; set; }
        public List<CleaningAdditionOutputModel> CleaningAdditions { get; set; }
    }
}
