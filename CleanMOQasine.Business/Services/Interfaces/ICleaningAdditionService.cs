
namespace CleanMOQasine.Business.Services
{
    public interface ICleaningAdditionService
    {
        void AddCleaningAddition(CleaningAdditionModel cleaningAdditionModel);
        void DeleteCleaningAddition(int id);
        List<CleaningAdditionModel> GetAllCleaningAdditions();
        CleaningAdditionModel GetCleaningAdditionById(int id);
        void RestoreCleaningAddition(int id);
        void UpdateCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel);
    }
}