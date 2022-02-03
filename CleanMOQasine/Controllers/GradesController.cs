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
            
            //if (neededGrade != null)
                return Ok();
            //else
                return BadRequest();
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
