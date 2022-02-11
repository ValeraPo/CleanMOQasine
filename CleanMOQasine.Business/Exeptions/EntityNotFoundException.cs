using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Exeptions
{
    public  class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string entityName) : base(@"{entityName} {id} cannot be found")
        {
        }
    }
}
