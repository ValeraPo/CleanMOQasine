using CleanMOQasine.Data.Entities;

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

        public IEnumerable<WorkingTime> GetAllWorkingTimes()
            => _context.WorkingHours.Where(p => !p.IsDeleted).ToList();

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

        public void AddWorkingTime(WorkingTime newWorkingTime, User user)
        {
            newWorkingTime.User = user;
            _context.WorkingHours.Add(newWorkingTime);
            _context.SaveChanges();
        }
    }
}
