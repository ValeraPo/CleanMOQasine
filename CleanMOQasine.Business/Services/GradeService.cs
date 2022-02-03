using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
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
            GradeRepository grade = new();
            var a = grade.GetGradeById(id);
            return AutoMapperToData.GetInstance().Map<GradeModel>(a);
        }
    }
}
