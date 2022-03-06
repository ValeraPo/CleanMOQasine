using AutoMapper;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Exceptions;

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
            CheckCleaningAddition(entity);
            return _autoMapperInstance.Map<CleaningAdditionModel>(entity);
        }

        public List<CleaningAdditionModel> GetAllCleaningAdditions()
        {
            var entities = _cleaningAdditionRepository.GetAllCleaningAdditions();
            return _autoMapperInstance.Map<List<CleaningAdditionModel>>(entities);
        }

        public List<CleaningAdditionModel> GetCleaningAdditionsByListIds(List<int> ids)
        {
            var listModels = new List<CleaningAdditionModel>();
            foreach (int id in ids)
            {
                var model = GetCleaningAdditionById(id);
                listModels.Add(model);
            }
            return listModels;
        }

        public void AddCleaningAdditionsByListIds(List<int> ids)
        {
            
        }

        public int AddCleaningAddition(CleaningAdditionModel cleaningAdditionModel)
        {
            var entity = _autoMapperInstance.Map<CleaningAddition>(cleaningAdditionModel);
            return _cleaningAdditionRepository.AddCleaningAddition(entity);
        }

        public void UpdateCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel)
        {
            var entity = _cleaningAdditionRepository.GetCleaningAdditionById(id);
            CheckCleaningAddition(entity);
            var entityUpdate = _autoMapperInstance.Map<CleaningAddition>(cleaningAdditionModel);
            _cleaningAdditionRepository.UpdateCleaningAddition(id, entityUpdate);
        }

        public void DeleteCleaningAddition(int id)
        {
            var entity = _cleaningAdditionRepository.GetCleaningAdditionById(id);
            CheckCleaningAddition(entity);
            _cleaningAdditionRepository.DeleteCleaningAddition(id);
        }

        public void RestoreCleaningAddition(int id)
        {
            var entity = _cleaningAdditionRepository.GetCleaningAdditionById(id);
            CheckCleaningAddition(entity);
            _cleaningAdditionRepository.RestoreCleaningAddition(id);
        }

        private void CheckCleaningAddition(CleaningAddition cleaningAddition)
        {
            if (cleaningAddition is null)
                throw new NotFoundException($"CleaningAddition not found");
        }

    }
}