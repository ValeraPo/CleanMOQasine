using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Services;

namespace CleanMOQasine.API.Services
{
    public class GradeServices
    {
        public GradeBaseOutputModel GetGradeById(int id)
        {
            GradeService grade = new();
            var model = grade.GetGradeById(id);
            return AutoMapperFromApi.GetInstance().Map<GradeBaseOutputModel>(model);
        }

    }
}
