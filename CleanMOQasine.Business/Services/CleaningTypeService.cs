using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Exceptions;

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
            CheckEntity(entity, typeof(CleaningType));
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
            GetCleaningTypeById(id);
            var entityUpdated = _autoMapperInstance.Map<CleaningType>(updatedCleaningTypeModel);
            _cleaningTypeRepository.UpdateCleaningType(id, entityUpdated);
        }

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            GetCleaningTypeById(cleaningTypeId);
            var cleaningAddition = _cleaningAdditionRepository.GetCleaningAdditionById(cleaningAdditionId);
            CheckEntity(cleaningAddition, typeof(CleaningAddition));
            _cleaningTypeRepository.AddCleaningAdditionToCleaningType(cleaningTypeId, cleaningAdditionId);
        }

        public void DeleteCleaningAdditionFromCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            var cleaningType = _cleaningTypeRepository.GetCleaningTypeById(cleaningTypeId);
            CheckEntity(cleaningType, typeof(CleaningType));

            var cleaningAddition = cleaningType.CleaningAdditions.FirstOrDefault(ca=>ca.Id==cleaningAdditionId);
            if (cleaningAddition is null)
                throw new NotFoundException("The CleaningAddition was not found in this CleaningType");

            _cleaningTypeRepository.DeleteCleaningAdditionFromCleaningType(cleaningTypeId, cleaningAdditionId);
        }

        public void DeleteCleaningType(int id)
        {
            GetCleaningTypeById(id);
            _cleaningTypeRepository.DeleteCleaningType(id);
        }

        public void RestoreCleaningType(int id)
        {
            GetCleaningTypeById(id);
            _cleaningTypeRepository.RestoreCleaningType(id);
        }

        private void CheckEntity(object entity, Type entityType)
        {
            if (entity is null)
                throw new NotFoundException($"The entity {entityType.Name} was not found");
        }
    }
}
