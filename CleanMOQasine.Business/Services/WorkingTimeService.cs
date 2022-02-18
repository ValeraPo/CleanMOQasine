using AutoMapper;
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
        private readonly IWorkingTimeRepository _repository;
        private readonly IMapper _mapper;

        public WorkingTimeService(IWorkingTimeRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<WorkingTimeModel> GetAllWorkingTimes()
        {
            var workingTimes = _repository.GetAllWorkingTimes();
            return _mapper.Map<List<WorkingTimeModel>>(workingTimes);
        }

        public WorkingTimeModel GetWorkingTimeById(int id)
        {
            var workingTime = _repository.GetWorkingTimeById(id);
            return _mapper.Map<WorkingTimeModel>(workingTime);
        }

        public void UpdateWorkingTime(WorkingTimeModel workingTimeModel, int id)
        {
            var workingTime = _mapper.Map<WorkingTime>(workingTimeModel);
            workingTime.Id = id;
            _repository.UpdateWorkingTime(workingTime);
        }

    }
}
