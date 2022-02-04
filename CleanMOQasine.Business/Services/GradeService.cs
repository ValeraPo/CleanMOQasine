using CleanMOQasine.Business.Configurations;
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
    public class GradeService
    {
        public GradeModel GetGradeById(int id)
        {
            GradeRepository repository = new();
            var grade = repository.GetGradeById(id);
            return AutoMapperToData.GetInstance().Map<GradeModel>(grade);
        }
        public void UpdateGrade(GradeModel grade)
        {
            GradeRepository repository = new();
            var updatedGrade = AutoMapperToData.GetInstance().Map<Grade>(grade);
            repository.UpdateGradeById(updatedGrade);
        }

        public IEnumerable<GradeModel> GetAllGrades()
        {
            GradeRepository repository = new();
            var grades = repository.GetAllGrades();
            return AutoMapperToData.GetInstance().Map<IEnumerable<GradeModel>>(grades);
        }

        public void AddGrade(GradeModel grade, int orderId)
        {
            GradeRepository repository = new();
            var newGrade = AutoMapperToData.GetInstance().Map<Grade>(grade);
            newGrade.OrderId = orderId;
            repository.AddGrade(newGrade);
        }
    }
}
