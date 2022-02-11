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
        private readonly IMapper _autoMapperInstance;

        public CleaningTypeService(ICleaningTypeRepository cleaningTypeRepository, IMapper mapper)
        {
            _cleaningTypeRepository = cleaningTypeRepository;
            _autoMapperInstance = mapper;
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

        public int AddCleaningType(CleaningTypeModel cleaningTypeModel)
        {
            var entity = _autoMapperInstance.Map<CleaningType>(cleaningTypeModel);
            return _cleaningTypeRepository.AddCleaningType(entity);
        }

        public bool UpdateCleaningType(int id, CleaningTypeModel updatedCleaningTypeModel)
        {
            var entity = _autoMapperInstance.Map<CleaningType>(updatedCleaningTypeModel);
            return _cleaningTypeRepository.UpdateCleaningType(id, entity);
        }

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            _cleaningTypeRepository.AddCleaningAdditionToCleaningType(cleaningTypeId, cleaningAdditionId);
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
