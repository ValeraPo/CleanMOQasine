using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeService(IGradeRepository gradeRpository)
        {
            _gradeRepository = gradeRpository;
        }

        public GradeModel GetGradeById(int id)
        {
            var grade = _gradeRepository.GetGradeById(id);
            return AutoMapperToData.GetInstance().Map<GradeModel>(grade);
        }

        public void UpdateGrade(GradeModel grade, int id)
        {
            if (GetGradeById(id) is null)
                return;
            var updatedGrade = AutoMapperToData.GetInstance().Map<Grade>(grade);
            updatedGrade.Id = id;
            _gradeRepository.UpdateGradeById(updatedGrade);
        }

        public List<GradeModel> GetAllGrades()
        {
            var grades = _gradeRepository.GetAllGrades();
            return AutoMapperToData.GetInstance().Map<List<GradeModel>>(grades);
        }

        public void AddGrade(GradeModel grade, int orderId)
        {
            var newGrade = AutoMapperToData.GetInstance().Map<Grade>(grade);
            newGrade.OrderId = orderId;
            _gradeRepository.AddGrade(newGrade);
        }

        public int DeleteGradeById(int id) 
            => (GetGradeById(id) is null) ? -1 : _gradeRepository.DeleteGradeById(id);
    }
}
