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
            return order.Client.FirstName.Equals(Client.FirstName)
                && order.Client.LastName.Equals(Client.LastName)
                && order.Client.Login.Equals(Client.Login)
                && order.CleaningType.Name.Equals(CleaningType.Name)
                && order.Address.Equals(Address)
                && order.Date.Equals(Date)
                && order.IsDeleted.Equals(IsDeleted)
                && order.Rooms.Select(r => r.Name).SequenceEqual<string>(Rooms.Select(r => r.Name))
                && order.CleaningAdditions.Select(r => r.Name).SequenceEqual<string>(CleaningAdditions.Select(r => r.Name)) 
                && order.Cleaners.Select(r => r.Login).SequenceEqual<string>(Cleaners.Select(r => r.Login))
                && order.Payments.Select(r => r.Amount).SequenceEqual<decimal>(Payments.Select(r => r.Amount));
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            
            return obj.GetType() == GetType() && Equals((Order)obj);
        }
    }
}
