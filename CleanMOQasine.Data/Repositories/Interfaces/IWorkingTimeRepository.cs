using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IWorkingTimeRepository
    {
        void AddWorkingTime(WorkingTime newWorkingTime);
        void DeleteWorkingTime(int id);
        List<WorkingTime> GetAllWorkingTimes();
        WorkingTime? GetWorkingTimeById(int id);
        void UpdateWorkingTime(WorkingTime workingTime);
    }
}