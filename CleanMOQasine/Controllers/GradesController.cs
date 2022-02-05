using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult GetGradeById(int id)
        {
            GradeService service = new();
            var model = service.GetGradeById(id);
            var grade = AutoMapperFromApi.GetInstance().Map<GradeBaseOutputModel>(model);
            if (grade != null)
                return Ok(grade);
            else
                return BadRequest("Grade does not exist");
        }

        [HttpGet]
        public ActionResult GetAllGrades ()
        {
            GradeService service = new();
            var model = service.GetAllGrades();
            return Ok(AutoMapperFromApi.GetInstance()
                .Map<IEnumerable<GradeBaseOutputModel>>(model));
        }

        [HttpDelete]
        public ActionResult DeleteGradeById(int id)
        {
            GradeService service = new();
            if (service.DeleteGradeById(id) == -1)
                return BadRequest();
            else
                return Ok();
        }

        [HttpPost]
        public ActionResult AddGrade(GradeBaseInputModel grade, int orderId)
        {

            GradeService service = new();
            var model = AutoMapperFromApi.GetInstance().Map<GradeModel>(grade);
            service.AddGrade(model, orderId);
            return StatusCode(StatusCodes.Status201Created, grade);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGrade(int id, GradeBaseInputModel grade)
        {
            GradeService service = new();
            grade.Id = id;
            var model = AutoMapperFromApi.GetInstance().Map<GradeModel>(grade);
            service.UpdateGrade(model);
            return Ok();
        }

    }
}
