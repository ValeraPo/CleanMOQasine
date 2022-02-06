using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMOQasine.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public virtual User Client { get; set; }
        public virtual CleaningType CleaningType { get; set; }
        public virtual Grade Grade { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<Room>? Rooms { get; set; }
        public virtual ICollection<CleaningAddition>? CleaningAdditions { get; set; } 
        public virtual ICollection<User>? Cleaners { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            Order order = (Order)obj;
            if (!order.Id.Equals(Id)
                || !order.Client.Equals(Client)
                || !order.CleaningType.Equals(CleaningType)
                || !order.Grade.Equals(Grade)
                || !order.Address.Equals(Address)
                || !order.Date.Equals(Date)
                || !order.IsDeleted.Equals(IsDeleted)
                || !order.Rooms.SequenceEqual<Room>(Rooms)
                || !order.CleaningAdditions.SequenceEqual<CleaningAddition>(CleaningAdditions)
                || !order.Cleaners.SequenceEqual<User>(Cleaners)
                || !order.Payments.SequenceEqual<Payment>(Payments))
                return false;
            return true;
        }
    }
}
