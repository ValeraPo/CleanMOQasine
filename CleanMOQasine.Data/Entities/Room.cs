namespace CleanMOQasine.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            Room room = (Room)obj;
            if (room.Id == Id
                && room.Name == Name
                && room.Price == Price
                && room.IsDeleted == IsDeleted)
                return true;
            return false;
        }

    }
}
