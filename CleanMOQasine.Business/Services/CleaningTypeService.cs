using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class CleaningTypeService : ICleaningTypeService
    {
        private readonly ICleaningTypeRepository _cleaningTypeRepository;
        private readonly Mapper _autoMapperInstance;
        public CleaningTypeService(ICleaningTypeRepository cleaningTypeRepository)
        {
            _cleaningTypeRepository = cleaningTypeRepository;
            _autoMapperInstance = AutoMapperToData.GetInstance();
        }

        public CleaningTypeModel GetCleaningTypeById(int id)
        {
            var entity = _cleaningTypeRepository.GetCleaningTypeById(id);
            return _autoMapperInstance.Map<CleaningTypeModel>(entity);
        }

        public List<CleaningTypeModel> GetAllCleaningTypes()
        {
            var entities = _cleaningTypeRepository.GetAllCleaningTypes();
            return _autoMapperInstance.Map<List<CleaningTypeModel>>(entities);
        }

        public void AddCleaningType(CleaningTypeModel cleaningTypeModel)
        {
            var entity = _autoMapperInstance.Map<CleaningType>(cleaningTypeModel);
            _cleaningTypeRepository.AddCleaningType(entity);
        }

        public void UpdateCleaningType(int id, CleaningTypeModel updatedCleaningTypeModel)
        {
            var entity = _autoMapperInstance.Map<CleaningType>(updatedCleaningTypeModel);
            _cleaningTypeRepository.UpdateCleaningType(id, entity);
        }

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, CleaningAdditionModel cleaningAdditionModel)
        {
            var entity = _autoMapperInstance.Map<CleaningAddition>(cleaningAdditionModel);
            _cleaningTypeRepository.AddCleaningAdditionToCleaningType(cleaningTypeId, entity);
        }

        public void DeleteCleaningType(int id)
        {
            _cleaningTypeRepository.DeleteCleaningType(id);
        }

        public void RestoreCleaningType(int id)
        {
            _cleaningTypeRepository.RestoreCleaningType(id);
        }
    }
}
