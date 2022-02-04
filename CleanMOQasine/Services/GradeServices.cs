using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;

namespace CleanMOQasine.API.Services
{
    public class GradeServices
    {
        public GradeBaseOutputModel GetGradeById(int id)
        {
            GradeService service = new();
            var model = service.GetGradeById(id);
            return AutoMapperFromApi.GetInstance().Map<GradeBaseOutputModel>(model);
        }

        public void UpdateGrade(GradeBaseInputModel grade)//??
        {
            GradeService service = new();
            var model = AutoMapperFromApi.GetInstance().Map<GradeModel>(grade);
            service.UpdateGrade(model);
        }

        public IEnumerable<GradeBaseOutputModel> GetAllGrades()
        {
            GradeService service = new();
            var model = service.GetAllGrades();
            return AutoMapperFromApi.GetInstance().Map<IEnumerable<GradeBaseOutputModel>>(model);
        }
    }
}
