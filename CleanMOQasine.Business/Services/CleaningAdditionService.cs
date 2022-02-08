using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanMOQasine.Data.Entities;
using AutoMapper;

namespace CleanMOQasine.Business.Services
{
    public class CleaningAdditionService
    {
        private readonly CleaningAdditionRepository _cleaningAdditionRepository;
        private readonly IMapper _autoMapperInstance;
        public CleaningAdditionService(IMapper mapper)
        {
            _cleaningAdditionRepository = new CleaningAdditionRepository();
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

        public void AddCleaningAddition(CleaningAdditionModel cleaningAdditionModel)
        {
            var entity = _autoMapperInstance.Map<CleaningAddition>(cleaningAdditionModel);
            _cleaningAdditionRepository.AddCleaningAddition(entity);
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
