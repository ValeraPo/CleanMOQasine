using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GradesController(IGradeService gradeService, IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _gradeService = gradeService;
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
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int userId = 0;
            bool isExist = false;
            if (identity != null)
            {
                List<Claim> claims = identity.Claims.ToList();
                userId = int.Parse(claims.Where(i =>
                i.Type == ClaimTypes.UserData).Select(c =>
                c.Value).SingleOrDefault());
            }
            var user = _userService.GetUserById(userId);
            foreach(var order in user.Orders)
            {
                if (order.Id == orderId)
                    isExist = true;
            }
            if (!isExist)
                return StatusCode(StatusCodes.Status400BadRequest, grade);
            var model = _mapper.Map<GradeModel>(grade);
            _gradeService.AddGrade(model, orderId);
            return StatusCode(StatusCodes.Status201Created, grade);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGrade(int id, [FromBody] GradeBaseInputModel grade)
        {
            var model = _mapper.Map<GradeModel>(grade);
            _gradeService.UpdateGrade(model, id);
            return Ok();
        }
    }
}
