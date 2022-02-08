using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface ICleaningTypeRepository
    {
        void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId);
        int AddCleaningType(CleaningType cleaningType);
        void DeleteCleaningType(int id);
        List<CleaningType> GetAllCleaningTypes();
        CleaningType GetCleaningTypeById(int id);
        void RestoreCleaningType(int id);
        bool UpdateCleaningType(int id, CleaningType updatedCleaningType);
    }
}