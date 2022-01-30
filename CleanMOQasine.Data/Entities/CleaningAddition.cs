using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMOQasine.Data.Entities
{
    public class CleaningAddition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public ICollection<OrderCleaningAddition> OrderCleaningAdditions { get; set; }
        public virtual ICollection<Order> Orders { get; set; } 
        public virtual ICollection<CleaningType> CleaningTypes { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsDeleted { get; set; }
    }
}
