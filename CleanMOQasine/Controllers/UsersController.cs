using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("The controller is used to get all users separately; register new clients; " +
        "add new admins, cleaners, clients; delete users and restore them")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _autoMapper;

        public UsersController(IUserService userService, IMapper autoMapper)
        {
            _userService = userService;
            _autoMapper = autoMapper;
        }

        //api/Users/23
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Get user by id. Roles: All.")]
        public ActionResult<UserOutputModel> GetUserById(int id)
        {
            var userModel = _userService.GetUserById(id);

            if (userModel is null)
                return NotFound($"User with id = {id} was not found");

            var output = _autoMapper.Map<UserOutputModel>(userModel);
            return Ok(output);
        }

        //api/Users
        [HttpGet("admins")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(List<UserOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation("Get all admins. Roles: Admin.")]
        public ActionResult<List<UserOutputModel>> GetAllAdmins()
        {
            var userModels = _userService.GetAllAdmins();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet("cleaners")]
        [ProducesResponseType(typeof(List<UserOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation("Get all cleaners. Roles: All, Anonymous.")]
        public ActionResult<List<UserOutputModel>> GetAllCleaners()
        {
            var userModels = _userService.GetAllCleaners();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet("clients")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(List<UserOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation("Get all clients. Roles: Admin.")]
        public ActionResult<List<UserOutputModel>> GetAllCLients()
        {
            var userModels = _userService.GetAllClients();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users/23
        [HttpPut("{id}")]
        [AuthorizeEnum(Role.Admin, Role.Client)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Update a user by id. Roles: Admin, Client.")]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateInputModel userUpdateInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userUpdateInputModel);
            _userService.UpdateUser(id, userModel);
            return Ok($"User with id = {id} was updated");
        }

        //api/Users
        [HttpPost("clients")]
        [AllowAnonymous]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Registrate a brand new client. Roles: Admin, Anonymous.")]
        public ActionResult<UserOutputModel> RegisterNewClient([FromBody] UserRegisterInputModel userRegisterInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userRegisterInputModel);
            _userService.CheckIfThatUserAlreadyExists(userModel);
            _userService.RegisterNewClient(userModel);
            return StatusCode(StatusCodes.Status201Created, userModel);
        }

        //api/Users
        [HttpPost]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Add a user. Roles: Admin.")]
        public ActionResult<UserOutputModel> AddUser([FromBody] UserInsertInputModel userInsertInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userInsertInputModel);
            _userService.CheckIfThatUserAlreadyExists(userModel);
            _userService.AddUser(userModel);
            return StatusCode(StatusCodes.Status201Created, userModel);
        }

        //api/Users/23
        [HttpDelete("{id}")]
        [AuthorizeEnum(Role.Admin, Role.Client)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete a user. Roles: Admin, Client.")]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUserById(id);
            return NoContent();
        }

        //api/Users/23
        [HttpPost("workingtime/{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(WorkingTimeOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<WorkingTimeOutputModel> AddCleanersWorkingTime([FromBody] WorkingTimeOutputModel workingTimeOutput,int id)
        {
            var workingTime = _autoMapper.Map<WorkingTimeModel>(workingTimeOutput);
            _userService.AddWorkingTime(workingTime,id);
            return StatusCode(StatusCodes.Status201Created, workingTime);
        }

        //api/Users/23
        [HttpPatch("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Restore a user. Roles: Admin.")]
        public ActionResult RestoreUser(int id)
        {
            _userService.RestoreUserById(id);
            return Ok($"User with id = {id} was restored");
        }
    }
}
