using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface ICleaningAdditionService
    {
        int AddCleaningAddition(CleaningAdditionModel cleaningAdditionModel);
        void DeleteCleaningAddition(int id);
        List<CleaningAdditionModel> GetAllCleaningAdditions();
        CleaningAdditionModel GetCleaningAdditionById(int id);
        void RestoreCleaningAddition(int id);
        void UpdateCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel);
        List<CleaningAdditionModel> GetCleaningAdditionsByListIds(List<int> ids);
        void AddCleaningAdditionToCleaner(int id, UserModel userModel);
    }
}