using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMOQasine.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual User Client { get; set; }
        public virtual CleaningType CleaningType { get; set; }
        public ICollection<OrderCleaningAddition> OrderCleaningAdditions { get; set; }
        public ICollection<CleaningAddition> CleaningAdditions { get; set; }   

        public ICollection<OrderUser> OrderUsers { get; set; }
        public virtual ICollection<User> Cleaners { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TotalDuration { get; set; }//nado ne nada
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
