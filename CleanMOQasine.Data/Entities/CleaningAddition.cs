using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMOQasine.Data.Entities
{
    public class CleaningAddition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Column(TypeName = "time(2)")]
        public TimeSpan Duration { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<CleaningType>? CleaningTypes { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            CleaningAddition addition = (CleaningAddition)obj;
            if (addition.Id == Id
                && addition.Name == Name
                && addition.Price == Price
                && addition.Duration == Duration
                && addition.IsDeleted == IsDeleted)
                return true;
            return false;
        }
    }
}
