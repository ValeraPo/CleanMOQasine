using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface ICleaningAdditionRepository
    {
        int AddCleaningAddition(CleaningAddition cleaningAddition);
        void DeleteCleaningAddition(int id);
        List<CleaningAddition> GetAllCleaningAdditions();
        CleaningAddition GetCleaningAdditionById(int id);
        //List<CleaningAddition> GetCleaningAdditionsByCleaningType(CleaningType cleaningType);
        void RestoreCleaningAddition(int id);
        void UpdateCleaningAddition(int id, CleaningAddition updatedCleaningAddition);

        void AddCleaningAdditionToCleaner(int cleaningAdditionId, int userId);
    }
}