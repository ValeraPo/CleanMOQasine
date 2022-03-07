using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class WorkingTimesController : Controller
    {
        private readonly IWorkingTimeService _workingTimeService;
        private readonly IUserService _userService;
        private readonly IMapper _autoMapper;

        public WorkingTimesController(IWorkingTimeService workingTimeService, IMapper autoMapper, IUserService userService)
        {
            _workingTimeService = workingTimeService;
            _userService = userService;
            _autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        [AuthorizeEnum(Role.Admin, Role.Cleaner)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get working time by Id. Roles: Admin, Cleaner")]
        public ActionResult<WorkingTimeOutputModel> GetWorkingTimeById(int id)
        {
            var workingTime = _workingTimeService.GetWorkingTimeById(id);
            this.CheckAccessCleanerToWorkingTime(workingTime.User.Id);
            var mappedWorkingTime = _autoMapper.Map<WorkingTimeOutputModel>(workingTime);
            return Ok(mappedWorkingTime);
        }

        [HttpGet]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation("Get all not deleted working times. Roles: Admin")]
        public ActionResult<List<WorkingTimeOutputModel>> GetAllWorkingTimes()
        {
            var workingTimes = _workingTimeService.GetAllWorkingTimes();
            var mappedWorkingTimes = _autoMapper.Map < List<WorkingTimeOutputModel>>(workingTimes);
            return Ok();
        }

        [HttpDelete]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Soft delete working time by Id. Roles: Admin")]
        public ActionResult DeleteWorkingTimeById(int id)
        {
            _workingTimeService.DeleteWorkingTimeById(id);
            return NoContent();
        }

        [HttpPost]
        [AuthorizeEnum(Role.Admin, Role.Cleaner)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Add working time with using cleaner Id. Roles: Admin, Cleaner")]
        public ActionResult AddWorkingTime([FromBody]WorkingTimeInsertInputModel workingTime, [FromQuery] int cleanerId)
        {
            var workingTimeModel = _autoMapper.Map<WorkingTimeModel>(workingTime);
            this.CheckAccessCleanerToWorkingTime(cleanerId);
            var userModel = _userService.GetUserById(cleanerId);
            _workingTimeService.AddWorkingTime(workingTimeModel, userModel);
            return StatusCode(StatusCodes.Status201Created, workingTime);
        }

        [HttpPut]
        [AuthorizeEnum(Role.Admin, Role.Cleaner)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Update working time by Id. Roles: Admin, Cleaner")]
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
        [SwaggerOperation("Get cleaner working times by cleaner Id. Roles: Admin, Cleaner")]
        public ActionResult<List<WorkingTimeOutputModel>> GetWorkingTimesByCleaner(int id)
        {
            this.CheckAccessCleanerToWorkingTime(id);
            var workingTimeModels = _workingTimeService.GetWorkingTimesByCleaner(id);
            var workingTimeOutputModels = _autoMapper.Map<List<WorkingTimeOutputModel>>(workingTimeModels);

            return Ok(workingTimeOutputModels);
        }
    }
}
