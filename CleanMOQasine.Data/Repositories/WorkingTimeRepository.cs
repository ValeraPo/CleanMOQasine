using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class WorkingTimeRepository : IWorkingTimeRepository
    {
        private readonly CleanMOQasineContext _context;
        public WorkingTimeRepository(CleanMOQasineContext context)
        {
            _context = context;
        }

        public WorkingTime? GetWorkingTimeById(int id)
            => _context.WorkingHours.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        public List<WorkingTime> GetAllWorkingTimes() => _context.WorkingHours.Where(p => !p.IsDeleted).ToList();

        public void UpdateWorkingTime(WorkingTime workingTime)
        {
            var oldWorkingTime = _context.WorkingHours.FirstOrDefault(p => p.Id == workingTime.Id);
            oldWorkingTime.Day = workingTime.Day;
            oldWorkingTime.EndTime = workingTime.EndTime;
            oldWorkingTime.StartTime = workingTime.StartTime;
            _context.SaveChanges();
        }

        public void DeleteWorkingTime(int id)
        {
            var workingTime = _context.WorkingHours.FirstOrDefault(p => p.Id == id);
            workingTime.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<WorkingTime> GetCleanersWorkingTimes(int userId)
        {
            var cleanerWorkingTimes = _context.WorkingHours
                .Include(u => u.User)
                .Where(w => !w.IsDeleted 
                && w.StartTime > TimeOnly.FromDateTime(DateTime.Now))
                .ToList();

            foreach(var working in cleanerWorkingTimes)
            {
                if (working.User.Id != userId)
                    cleanerWorkingTimes.Remove(working);
            }
            return cleanerWorkingTimes;
        }

        public void AddWorkingTime(WorkingTime newWorkingTime, int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
            user.WorkingHours.Add(newWorkingTime);
            _context.SaveChanges();
        }

        public List<WorkingTime> GetWorkingTimesByCleaner(int cleanerId)
        {
            var cleanerWorkingTimes = _context.WorkingHours
                .Where(wh=>wh.User.Id==cleanerId)
                .ToList();
            return cleanerWorkingTimes;
        }
    }
}
