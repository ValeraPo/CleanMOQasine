namespace CleanMOQasine.Business.Models
{
    public class CleaningTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderModel> Order { get; set; }
        public List<CleaningAdditionModel> CleaningAdditions { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CleaningTypeModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Price == model.Price;
        }
    }
}
