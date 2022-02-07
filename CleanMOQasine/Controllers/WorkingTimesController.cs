using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingTimesController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<WorkingTimeModel> GetWorkingTimeById(int id)
        {
            //if () WorkingTime is null
            return BadRequest();
            //else
            return Ok();

        }

        [HttpGet]
        public ActionResult<List<WorkingTimeModel>> GetAllWorkingTimes()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteWorkingTimeById(int id)
        {
            //if () WorkingTime is null
            return BadRequest();
            //else
            return Ok();
        }
        [HttpPost]
        public ActionResult AddWorkingTime(WorkingTimeModel workingTime)
        {
            return StatusCode(StatusCodes.Status201Created, workingTime);
        }

        [HttpPut]
        public ActionResult UpdateWorkingTime(WorkingTimeModel workingTime)
        {
            //if () WorkingTime is null
            return BadRequest();
            //else
            return Ok();
        }
    }
}
