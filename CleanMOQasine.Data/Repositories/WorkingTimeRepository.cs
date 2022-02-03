using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class WorkingTimeRepository
    {
        private readonly CleanMOQasineContext _context;

        public WorkingTimeRepository()
        {
            _context = CleanMOQasineContext.GetInstance();
        }

        //getall
        //getOne
        //Update
        //delete
        //add
    }
}
