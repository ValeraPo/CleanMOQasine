using AutoMapper;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Services
{
    public class WorkingTimeService : IWorkingTimeService
    {
        private readonly IWorkingTimeRepository _workingTimeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public WorkingTimeService(IWorkingTimeRepository workingTimeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _workingTimeRepository = workingTimeRepository;
            _userRepository = userRepository;
        }

        public List<WorkingTimeModel> GetAllWorkingTimes()
        {
            var workingTimes = _workingTimeRepository.GetAllWorkingTimes();
            return _mapper.Map<List<WorkingTimeModel>>(workingTimes);
        }

        public WorkingTimeModel GetWorkingTimeById(int id)
        {
            var workingTime = _workingTimeRepository.GetWorkingTimeById(id);
            return _mapper.Map<WorkingTimeModel>(workingTime);
        }

        public void UpdateWorkingTime(WorkingTimeModel workingTimeModel, int id)
        {
            if (_workingTimeRepository.GetWorkingTimeById(id) is null)
                throw new NotFoundException($"Working time with id {id} does not exists");
            var workingTime = _mapper.Map<WorkingTime>(workingTimeModel);
            workingTime.Id = id;
            _workingTimeRepository.UpdateWorkingTime(workingTime);
        }

        public void DeleteWorkingTimeById(int id)
        {
            if (_workingTimeRepository.GetWorkingTimeById(id) is null)
                throw new NotFoundException($"Working time with id {id} does not exists");
            _workingTimeRepository.DeleteWorkingTime(id);
        }
        public List<WorkingTimeModel> GetWorkingTimesByCleaner(int cleanerId)
        {
            var user = _userRepository.GetUserById(cleanerId);
            if (user == null)
                throw new NotFoundException("Вы пытаетесь узнать время работы у несуществующего пользователя");
            if (user.Role != Data.Enums.Role.Cleaner)
                throw new NoAccessException("Пользователь не является уборщиком");

            var workingHours = _workingTimeRepository.GetWorkingTimesByCleaner(cleanerId);
            return _mapper.Map<List<WorkingTimeModel>>(workingHours);
        }

        public void AddWorkingTime(WorkingTimeModel workingTimeModel, UserModel userModel)
        {
            if (workingTimeModel.StartTime >= workingTimeModel.EndTime)
                throw new Exception("Время начала рабочего дня не может быть больше или равно времени окончания");

            var user = _userRepository.GetUserById(userModel.Id);
            if (user == null)
                throw new NotFoundException("Вы пытаетесь добавить время работы к несуществующему пользователю");
            if (user.Role != Data.Enums.Role.Cleaner)
                throw new NoAccessException("Пользователь не является уборщиком");
            
            var isValidDay = GetWorkingTimesByCleaner(userModel.Id).Any(wt => wt.Day == workingTimeModel.Day);
            if (isValidDay)
                throw new Exception("Такой день недели уже существует у данного работника");

            var workingTime = _mapper.Map<WorkingTime>(workingTimeModel);
            workingTimeModel.User = userModel;
            workingTime.User = user;
            _workingTimeRepository.AddWorkingTime(workingTime, userModel.Id);

        }
        
    }
}
