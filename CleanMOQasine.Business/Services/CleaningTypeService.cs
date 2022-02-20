using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Exceptions;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class CleaningTypeService : ICleaningTypeService
    {
        private readonly ICleaningTypeRepository _cleaningTypeRepository;
        private readonly ICleaningAdditionRepository _cleaningAdditionRepository;
        private readonly IMapper _autoMapperInstance;

        public CleaningTypeService(ICleaningTypeRepository cleaningTypeRepository, ICleaningAdditionRepository cleaningAdditionRepository, IMapper mapper)
        {
            _cleaningTypeRepository = cleaningTypeRepository;
            _cleaningAdditionRepository = cleaningAdditionRepository;
            _autoMapperInstance = mapper;
        }

        public CleaningTypeModel GetCleaningTypeById(int id)
        {
            var entity = _cleaningTypeRepository.GetCleaningTypeById(id);
            CheckEntity(entity, "CleanigType");
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

        public void UpdateCleaningType(int id, CleaningTypeModel updatedCleaningTypeModel)
        {
            var entity = _cleaningTypeRepository.GetCleaningTypeById(id);
            CheckEntity(entity, "CleanigType");
            var entityUpdated = _autoMapperInstance.Map<CleaningType>(updatedCleaningTypeModel);
            _cleaningTypeRepository.UpdateCleaningType(id, entity);
        }

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            var cleaningType = _cleaningTypeRepository.GetCleaningTypeById(cleaningTypeId);
            CheckEntity(cleaningType, "CleanigType");
            var cleaningAddition = _cleaningAdditionRepository.GetCleaningAdditionById(cleaningAdditionId);
            CheckEntity(cleaningAddition, "CleanigAddition");
            _cleaningTypeRepository.AddCleaningAdditionToCleaningType(cleaningTypeId, cleaningAdditionId);
        }

        public void DeleteCleaningType(int id)
        {
            var entity = _cleaningTypeRepository.GetCleaningTypeById(id);
            CheckEntity(entity, "CleanigType");
            _cleaningTypeRepository.DeleteCleaningType(id);
        }

        public void RestoreCleaningType(int id)
        {
            var entity = _cleaningTypeRepository.GetCleaningTypeById(id);
            CheckEntity(entity, "CleanigType");
            _cleaningTypeRepository.RestoreCleaningType(id);
        }

        private void CheckEntity(object entity, string name)
        {
            if (entity is null)
                throw new NotFoundException($"The entity {name} was not found");
        }
    }
}
