using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Entities
{
    public class OrderCleaningAddition
    {
        public int OrderId { get; set; }
        public  Order Order { get; set; }//virtual?

        public int CleaningAdditionId { get; set; }
        public CleaningAddition CleaningAddition { get; set; }

    }
}
