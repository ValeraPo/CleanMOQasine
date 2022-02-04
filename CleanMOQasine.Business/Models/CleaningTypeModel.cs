using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Models
{
    public class CleaningTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderModel> Order { get; set; } //наверное это и не надо здесь по логике
        public ICollection<CleaningAdditionModel> CleaningAdditions { get; set; }
    }
}
