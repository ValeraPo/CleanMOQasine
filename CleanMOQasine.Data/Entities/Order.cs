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
    }
}
