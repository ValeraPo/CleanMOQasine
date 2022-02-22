using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business
{
    public class CleaningAdditionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public List<OrderModel> Orders { get; set; }
        public List<CleaningTypeModel> CleaningTypes { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CleaningAdditionModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Price == model.Price &&
                   Duration.Equals(model.Duration) &&
                   IsDeleted == model.IsDeleted;
        }

    }
}