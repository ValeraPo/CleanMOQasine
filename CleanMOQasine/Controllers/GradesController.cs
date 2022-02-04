using CleanMOQasine.API.Models;
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
            GradeServices service = new();
            var grades = service.GetAllGrades();
            return Ok(grades);
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

        [HttpPut("{id}")]
        public ActionResult UpdateGrade(int id, GradeBaseInputModel grade)
        {
            grade.Id = id;
            GradeServices service = new();
            service.UpdateGrade(grade);//не апдейтит
            return Ok();
        }

    }
}
