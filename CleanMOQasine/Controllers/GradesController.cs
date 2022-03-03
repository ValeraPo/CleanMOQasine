using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Extensions;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public GradesController(IGradeService gradeService, IOrderService orderService, IMapper mapper)
        {
            _gradeService = gradeService;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(GradeBaseOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetGradeById(int id)
        {
            var model = _gradeService.GetGradeById(id);
            var grade = _mapper.Map<GradeBaseOutputModel>(model);
            if (grade != null)
                return Ok(grade);
            else
                return BadRequest("Grade does not exist");
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<GradeBaseOutputModel>), StatusCodes.Status200OK)]
        public ActionResult GetAllGrades()
        {
            var model = _gradeService.GetAllGrades();
            return Ok(_mapper
                .Map<List<GradeBaseOutputModel>>(model));
        }

        [HttpDelete]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult DeleteGradeById(int id)
        {
            _gradeService.DeleteGradeById(id);
            return NoContent();
        }

        [HttpPost]
        [AuthorizeEnum(Role.Client)]
        [ProducesResponseType(typeof(GradeBaseOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult AddGrade([FromBody] GradeBaseInputModel grade, [FromQuery] int orderId)
        {
            var clientId = this.GetUserId();
            var orders = _orderService.GetOrdersByClientId(clientId);
            this.CheckCustomerOrder(orders, orderId);
            var model = _mapper.Map<GradeModel>(grade);
            _gradeService.AddGrade(model, orderId);
            return StatusCode(StatusCodes.Status201Created, grade);
        }

        [HttpPut("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(GradeBaseOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult UpdateGrade(int id, [FromBody] GradeBaseInputModel grade)
        {
            var model = _mapper.Map<GradeModel>(grade);
            _gradeService.UpdateGrade(model, id);
            return Ok();
        }

        [HttpGet("cleaners/{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(List<GradeBaseOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetCleanerGrades(int id)
        {
            var cleanerGrades = _gradeService.GetAllGradesByCleanerId(id);
            return Ok(cleanerGrades);
        }
    }
}
