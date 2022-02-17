using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IWorkingTimeService
    {
        List<WorkingTimeModel> GetAllWorkingTimes();
    }
}