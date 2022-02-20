using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface ICleaningTypeService
    {
        void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId);
        int AddCleaningType(CleaningTypeModel cleaningTypeModel);
        void DeleteCleaningType(int id);
        List<CleaningTypeModel> GetAllCleaningTypes();
        CleaningTypeModel GetCleaningTypeById(int id);
        void RestoreCleaningType(int id);
        void UpdateCleaningType(int id, CleaningTypeModel updatedCleaningTypeModel);
    }
}