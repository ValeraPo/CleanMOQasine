using AutoMapper;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public class CleaningAdditionService : ICleaningAdditionService
    {
        private readonly ICleaningAdditionRepository _cleaningAdditionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _autoMapperInstance;

        public CleaningAdditionService(ICleaningAdditionRepository cleaningAdditionRepository, IUserRepository userRepository, IMapper mapper)
        {
            _cleaningAdditionRepository = cleaningAdditionRepository;
            _userRepository = userRepository;
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

        public void AddCleaningAdditionToCleaner(int id, UserModel userModel)
        {
            var user = _userRepository.GetUserById(userModel.Id);
            if (user == null || user.IsDeleted)
                throw new NotFoundException("Вы пытаетеь добавить навык к несуществующему или удалённому пользователю");

            if (user.Role != Data.Enums.Role.Cleaner)
                throw new NoAccessException("Пользователь не является клинером");

            var cleaningAddition = _cleaningAdditionRepository.GetCleaningAdditionById(id);
            if (cleaningAddition == null || cleaningAddition.IsDeleted)
                throw new NotFoundException("Дополнение к уборке не найдено или удалено");

            if (userModel.CleaningAdditions == null)
                userModel.CleaningAdditions = new();

            userModel.CleaningAdditions.Add(_autoMapperInstance.Map<CleaningAdditionModel>(cleaningAddition));
            _cleaningAdditionRepository.AddCleaningAdditionToCleaner(id, userModel.Id);

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