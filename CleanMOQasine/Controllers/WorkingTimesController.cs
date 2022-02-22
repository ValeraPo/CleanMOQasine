using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkingTimesController : Controller
    {
        private readonly IWorkingTimeService _workingTimeService;
        private readonly IMapper _autoMapper;

        public WorkingTimesController(IWorkingTimeService workingTimeService, IMapper autoMapper)
        {
            _workingTimeService = workingTimeService;
            _autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        public ActionResult<WorkingTimeModel> GetWorkingTimeById(int id)
        {
            return Ok(_workingTimeService.GetWorkingTimeById(id));
        }

        [HttpGet]
        public ActionResult<List<WorkingTimeModel>> GetAllWorkingTimes()
        {
            return Ok(_workingTimeService.GetAllWorkingTimes());
        }

        [HttpDelete]
        public ActionResult DeleteWorkingTimeById(int id)
        {
            _workingTimeService.DeleteWorkingTimeById(id);
            return NoContent();
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
