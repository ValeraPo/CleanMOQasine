using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanMOQasine.Business.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRpository, IMapper mapper,
            IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _gradeRepository = gradeRpository;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public GradeModel GetGradeById(int id)
        {
            var grade = _gradeRepository.GetGradeById(id);
            CheckEntity(grade, typeof(Grade));
            return _mapper.Map<GradeModel>(grade);
        }

        public void UpdateGrade(GradeModel grade, int id)
        {
            GetGradeById(id);
            var updatedGrade = _mapper.Map<Grade>(grade);
            updatedGrade.Id = id;
            _gradeRepository.UpdateGradeById(updatedGrade);
        }

        public List<GradeModel> GetAllGrades()
        {
            var grades = _gradeRepository.GetAllGrades();
            return _mapper.Map<List<GradeModel>>(grades);
        }

        public void AddGrade(GradeModel grade, int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            CheckEntity(order, typeof(Order));
            var newGrade = _mapper.Map<Grade>(grade);
            _gradeRepository.AddGrade(newGrade, orderId);
        }

        public void DeleteGradeById(int id)
        {
            GetGradeById(id);
            _gradeRepository.DeleteGradeById(id);
        }

        public List<GradeModel> GetAllGradesByCleanerId(int cleanerId)
        {
            var cleaner = _userRepository.GetUserById(cleanerId);
            CheckEntity(cleaner, typeof(User));
            if (cleaner.Role is not Data.Enums.Role.Cleaner)
                throw new NotFoundException($"The cleaner {cleaner.Id} was not found");
            var grades = _gradeRepository.GetGradesByCleaner(cleanerId);
            return _mapper.Map<List<GradeModel>>(grades);
        }

        private void CheckEntity(object entity, Type entityType)
        {
            if (entity is null)
                throw new NotFoundException($"The entity {entityType.Name} was not found");
        }
    }
}
