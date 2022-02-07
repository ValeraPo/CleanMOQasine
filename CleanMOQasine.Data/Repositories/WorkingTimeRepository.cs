using CleanMOQasine.Data.Entities;
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
        }
        public WorkingTime? GetWorkingTimeById(int id)
           => _context.WorkingHours.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        public IEnumerable<WorkingTime> GetAllWorkingTimes()
            => _context.WorkingHours.Where(p => !p.IsDeleted).ToList();

        public void UpdateWorkingTime(WorkingTime workingTime)
        {
            var oldWorkingTime = _context.WorkingHours.FirstOrDefault(p => p.Id == workingTime.Id);
            oldWorkingTime = workingTime;
            _context.SaveChanges();
        }

        public void DeleteWorkingTime(int id)
        {
            var workingTime = _context.WorkingHours.FirstOrDefault(p => p.Id == id);
            workingTime.IsDeleted = true;
            _context.SaveChanges();
        }

        public void AddWorkingTime(WorkingTime newWorkingTime)
        {
            _context.WorkingHours.Add(newWorkingTime);
            _context.SaveChanges();
        }
    }
}
