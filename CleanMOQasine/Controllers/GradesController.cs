using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Extensions;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public ActionResult GetAllGrades()
        {
            var model = _gradeService.GetAllGrades();
            return Ok(_mapper
                .Map<IEnumerable<GradeBaseOutputModel>>(model));
        }

        [HttpDelete]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult DeleteGradeById(int id)
        {
            _gradeService.DeleteGradeById(id);
            return NoContent();
        }

        [HttpPost]
        [AuthorizeEnum(Role.Client)]
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
        public ActionResult UpdateGrade(int id, [FromBody] GradeBaseInputModel grade)
        {
            var model = _mapper.Map<GradeModel>(grade);
            _gradeService.UpdateGrade(model, id);
            return Ok();
        }

        [HttpGet("cleaners/{id}")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult GetCleanerGrades(int id)
        {
            var cleanerGrades = _gradeService.GetAllGradesByCleanerId(id);
            return Ok(cleanerGrades);
        }
    }
}
