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
        public List<OrderModel> Order { get; set; } 
        public List<CleaningAdditionModel> CleaningAdditions { get; set; }
    }
}
