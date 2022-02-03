using CleanMOQasine.API.Services;
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
            GradeServices service = new();
            var grade = service.GetGradeById(id);
            if (grade != null)
                return Ok(grade);
            else
                return BadRequest("Grade does not exist");
        }

        [HttpGet]
        public ActionResult GetAllGrades ()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteGradeById(int id)
        {
            //if method to delete by id == -1
                return BadRequest();
            //else
                return Ok();
        }

        [HttpPost]
        public ActionResult AddGrade(Grade grade)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateGrade(Grade grade)
        {
            return Ok();
        }

    }
}
