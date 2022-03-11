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
    [SwaggerTag("The controller is used to interact with clients")]
    public class ClientsController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICleaningAdditionService _cleaningAdditionService;
        private readonly IWorkingTimeService _workingTimeService;
        private readonly IMapper _autoMapper;

        public ClientsController(IUserService userService, ICleaningAdditionService cleaningAdditionService, IWorkingTimeService workingTimeService, IMapper autoMapper)
        {
            _userService = userService;
            _cleaningAdditionService = cleaningAdditionService;
            _workingTimeService = workingTimeService;
            _autoMapper = autoMapper;
        }

        //api/Users/23
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Get client by id. Roles: All.")]
        public ActionResult<UserOutputModel> GetClientById(int id)
        {
            var userModel = _userService.GetUserById(id); // сделать ClientById

            if (userModel is null)
                return NotFound($"Client with id = {id} was not found");

            var output = _autoMapper.Map<UserOutputModel>(userModel);
            return Ok(output);
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
        [SwaggerOperation("Update a client by id. Roles: Admin, Client.")]
        public ActionResult UpdateClient(int id, [FromBody] UserUpdateInputModel userUpdateInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userUpdateInputModel); //Сделать UpdateClient
            _userService.UpdateUser(id, userModel);
            return Ok($"User with id = {id} was updated");
        }

        //api/Users
        [HttpPost("clients")]
        [AllowAnonymous]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Register a brand new client. Roles: Admin, Anonymous.")]
        public ActionResult<UserOutputModel> RegisterNewClient([FromBody] ClientInsertInputModel userRegisterInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userRegisterInputModel);
            var user = _userService.RegisterNewClient(userModel);
            return StatusCode(StatusCodes.Status201Created, user);
        }

        //api/Users/23
        [HttpDelete("{id}")]
        [AuthorizeEnum(Role.Admin, Role.Client)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete a client. Roles: Admin, Client.")]
        public ActionResult DeleteClient(int id) 
        {
            _userService.DeleteUserById(id); //DeleteClient
            return NoContent();
        }

        //api/Users/23
        [HttpPatch("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Restore a client. Roles: Admin.")]
        public ActionResult RestoreClient(int id)
        {
            _userService.RestoreUserById(id); //RestoreClient
            return Ok($"Client with id = {id} was restored");
        }
    }
}
