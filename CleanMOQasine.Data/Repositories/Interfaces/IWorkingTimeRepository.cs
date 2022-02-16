using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IWorkingTimeRepository
    {
        void AddWorkingTime(WorkingTime newWorkingTime, User user);
        void DeleteWorkingTime(int id);
        IEnumerable<WorkingTime> GetAllWorkingTimes();
        WorkingTime? GetWorkingTimeById(int id);
        void UpdateWorkingTime(WorkingTime workingTime);
    }
}