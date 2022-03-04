using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.API.Extensions;

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
        public ActionResult UpdateWorkingTime(WorkingTimeOutputModel workingTime, [FromQuery] int id)
        {
            var workingTimeBusinesModel = _autoMapper.Map<WorkingTimeModel>(workingTime);
            _workingTimeService.UpdateWorkingTime(workingTimeBusinesModel, id);
            return Ok();
        }

        [HttpGet("cleaners/{id}/workingtimes")]
        [AuthorizeEnum(Role.Admin, Role.Cleaner)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<WorkingTimeOutputModel>> GetWorkingTimesByCleaner(int id)
        {
            this.CheckAccessCleanerToWorkingTime(id);
            var workingTimeModels = _workingTimeService.GetWorkingTimesByCleaner(id);
            var workingTimeOutputModels = _autoMapper.Map<List<WorkingTimeOutputModel>>(workingTimeModels);

            return Ok(workingTimeOutputModels);
        }
    }
}
