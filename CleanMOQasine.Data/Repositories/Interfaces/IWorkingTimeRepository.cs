using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IWorkingTimeRepository
    {
        void AddWorkingTime(WorkingTime newWorkingTime, int userId);
        void DeleteWorkingTime(int id);
        List<WorkingTime> GetAllWorkingTimes();
        WorkingTime? GetWorkingTimeById(int id);
        void UpdateWorkingTime(WorkingTime workingTime);
        List<WorkingTime> GetCleanersWorkingTimes(int userId);
    }
}