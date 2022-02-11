using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public bool Equals(Order order)
        {
            return order.Client.FirstName.Equals(Client.FirstName) // TODO заменить на order.Client.Equals(Client) когда будет написано для Equals for User
                && order.CleaningType.Name.Equals(CleaningType.Name) // TODO
                && order.Address.Equals(Address)
                && order.Date.Equals(Date)
                && order.IsDeleted.Equals(IsDeleted)
                && order.Rooms.Select(r => r.Name).SequenceEqual<string>(Rooms.Select(r => r.Name)) //TODO
                && order.CleaningAdditions.Select(r => r.Name).SequenceEqual<string>(CleaningAdditions.Select(r => r.Name)) //TODO
                && order.Cleaners.Select(r => r.FirstName).SequenceEqual<string>(Cleaners.Select(r => r.FirstName)) //TODO
                && order.Payments.Select(r => r.Amount).SequenceEqual<decimal>(Payments.Select(r => r.Amount)); //TODO
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            
            return obj.GetType() == GetType() && Equals((Order)obj);
        }
    }
}
