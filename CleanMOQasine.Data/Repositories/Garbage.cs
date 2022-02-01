using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class Garbage
    {
        private static Garbage instance;
        public CleanMOQasineContext Context { get; set; }

        private Garbage()
        {
            Context = new();
        }

        public static Garbage GetInstance()
        {
            if (instance == null)
                instance = new Garbage();
            return instance;
        }



    }
}
