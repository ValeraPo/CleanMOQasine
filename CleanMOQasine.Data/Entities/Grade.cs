using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
    }
}
