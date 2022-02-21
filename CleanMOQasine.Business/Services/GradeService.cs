using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Business.Exceptions;

namespace CleanMOQasine.Business.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        public GradeService(IGradeRepository gradeRpository, IMapper mapper)
        {
            _gradeRepository = gradeRpository;
            _mapper = mapper;
        }

        public GradeModel GetGradeById(int id)
        {
            var grade = _gradeRepository.GetGradeById(id);
            return _mapper.Map<GradeModel>(grade);
        }

        public void UpdateGrade(GradeModel grade, int id)
        {
            if (GetGradeById(id) is null)
                throw new NotFoundException($"Grade with {id} not found");
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
            var newGrade = _mapper.Map<Grade>(grade);
            _gradeRepository.AddGrade(newGrade, orderId);
        }

        public void DeleteGradeById(int id)
        {
            if (GetGradeById(id) is null)
                throw new NotFoundException($"Grade with {id} not found");
            _gradeRepository.DeleteGradeById(id);
        }
    }
}
