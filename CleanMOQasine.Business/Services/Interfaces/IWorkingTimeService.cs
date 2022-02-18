using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IWorkingTimeService
    {
        List<WorkingTimeModel> GetAllWorkingTimes();
        WorkingTimeModel GetWorkingTimeById(int id);
        void UpdateWorkingTime(WorkingTimeModel workingTimeModel, int id);
        void DeleteWorkingTimeById(int id);
    }
}