using AutoMapper;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class CleaningAdditionService : ICleaningAdditionService
    {
        private readonly ICleaningAdditionRepository _cleaningAdditionRepository;
        private readonly IMapper _autoMapperInstance;
        public CleaningAdditionService(ICleaningAdditionRepository cleaningAdditionRepository, IMapper mapper)
        {
            _cleaningAdditionRepository = cleaningAdditionRepository;
            _autoMapperInstance = mapper;
        }

        public CleaningAdditionModel GetCleaningAdditionById(int id)
        {
            var entity = _cleaningAdditionRepository.GetCleaningAdditionById(id);
            return _autoMapperInstance.Map<CleaningAdditionModel>(entity);
        }

        public List<CleaningAdditionModel> GetAllCleaningAdditions()
        {
            var entities = _cleaningAdditionRepository.GetAllCleaningAdditions();
            return _autoMapperInstance.Map<List<CleaningAdditionModel>>(entities);
        }

        public int AddCleaningAddition(CleaningAdditionModel cleaningAdditionModel)
        {
            var entity = _autoMapperInstance.Map<CleaningAddition>(cleaningAdditionModel);
            return _cleaningAdditionRepository.AddCleaningAddition(entity);
        }

        public void UpdateCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel)
        {
            var entity = _autoMapperInstance.Map<CleaningAddition>(cleaningAdditionModel);
            _cleaningAdditionRepository.UpdateCleaningAddition(id, entity);
        }

        public void DeleteCleaningAddition(int id)
        {
            _cleaningAdditionRepository.DeleteCleaningAddition(id);
        }

        public void RestoreCleaningAddition(int id)
        {
            _cleaningAdditionRepository.RestoreCleaningAddition(id);
        }

        //TODO: GetCleaningAdditionsByCleaningType

    }
}