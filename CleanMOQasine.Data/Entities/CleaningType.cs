using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Entities
{
    public class CleaningType
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public List<CleaningAddition> CleaningAdditions { get; set; }   
        public bool IsDeleted { get; set; }
    }
}
