using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Exeptions
{
    public class ServiceExeption: Exception
    {
        public ServiceExeption(string message): base(message)
        {

        }
    }
}
