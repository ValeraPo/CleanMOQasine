namespace CleanMOQasine.Business.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderModel> Orders { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            RoomModel roomModel = (RoomModel)obj;
            if (roomModel.Id == Id
                && roomModel.Name == Name
                && roomModel.Price == Price
                && roomModel.IsDeleted == IsDeleted)
                return false;
            return true;
        }
    }
}
