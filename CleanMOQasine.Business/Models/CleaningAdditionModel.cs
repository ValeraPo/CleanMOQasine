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

        //TODO:
        //public ICollection<UserModel> Users { get; set; //наверное это и не надо здесь
    }
}