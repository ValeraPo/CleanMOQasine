using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : Controller
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
            return View();
        }
        [HttpDelete]
        public ActionResult DeleteGradeById(int id)
        {
            //if method to delete by id == -1
                return BadRequest();
            //else
                return Ok();
        }

        public ActionResult AddGrade(int orderId, int mark, bool isAnonimous, string comment )
        {
            return Ok();
        }
    }
}
