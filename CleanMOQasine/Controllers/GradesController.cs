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
        private readonly IGradeService _gradeService;
        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("{id}")]
        public ActionResult GetGradeById(int id)
        {
            var model = _gradeService.GetGradeById(id);
            var grade = AutoMapperFromApi.GetInstance().Map<GradeBaseOutputModel>(model);
            if (grade != null)
                return Ok(grade);
            else
                return BadRequest("Grade does not exist");
        }

        [HttpGet]
        public ActionResult GetAllGrades ()
        {
            var model = _gradeService.GetAllGrades();
            return Ok(AutoMapperFromApi.GetInstance()
                .Map<IEnumerable<GradeBaseOutputModel>>(model));
        }

        [HttpDelete]
        public ActionResult DeleteGradeById(int id)
        {
            if (_gradeService.DeleteGradeById(id) == -1)
                return BadRequest();
            else
                return Ok();
        }

        [HttpPost]
        public ActionResult AddGrade(GradeBaseInputModel grade, int orderId)
        {

            var model = AutoMapperFromApi.GetInstance().Map<GradeModel>(grade);
            _gradeService.AddGrade(model, orderId);
            return StatusCode(StatusCodes.Status201Created, grade);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGrade(int id, GradeBaseInputModel grade)
        {
            var model = AutoMapperFromApi.GetInstance().Map<GradeModel>(grade);
            _gradeService.UpdateGrade(model, id);
            return Ok();
        }

    }
}
