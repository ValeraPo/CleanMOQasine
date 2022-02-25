using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Description("Get user by id")]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(AuthenticationException), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
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
        [Description("Get all admins")]
        [ProducesResponseType(typeof(UserOutputModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(AuthenticationException), StatusCodes.Status403Forbidden)]
        public ActionResult<List<UserOutputModel>> GetAllAdmins()
        {
            var userModels = _userService.GetAllAdmins();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet("cleaners")]
        [Description("Get all cleaners")]
        public ActionResult<List<UserOutputModel>> GetAllCleaners()
        {
            var userModels = _userService.GetAllCleaners();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet("clients")]
        [AuthorizeEnum(Role.Admin)]
        [Description("Get all clients")]
        public ActionResult<List<UserOutputModel>> GetAllCLients()
        {
            var userModels = _userService.GetAllClients();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users/23
        [HttpPut("{id}")]
        [Authorize]
        [Description("Update user by id")]
        [ProducesResponseType(typeof(ValidationException), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateInputModel userUpdateInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userUpdateInputModel);
            _userService.UpdateUser(id, userModel);
            return Ok($"User with Id = {id} was updated");
        }

        //api/Users
        [HttpPost("clients")]
        [Description("Register new client")]
        public ActionResult<UserModel> RegisterNewClient([FromBody] UserRegisterInputModel userRegisterInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userRegisterInputModel);
            CheckUser(userModel);
            _userService.RegisterNewClient(userModel);
            return StatusCode(StatusCodes.Status201Created, userModel);
        }

        //api/Users
        [HttpPost]
        [AuthorizeEnum(Role.Admin)]
        [Description("Add a user")]
        public ActionResult<UserModel> AddUser([FromBody] UserInsertInputModel userInsertInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userInsertInputModel);
            CheckUser(userModel);
            _userService.AddUser(userModel);
            return StatusCode(StatusCodes.Status201Created, userModel);
        }

        //api/Users/23
        [HttpDelete("{id}")]
        [AuthorizeEnum(Role.Admin, Role.Client)]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUserById(id);
            return NoContent();
        }

        //api/Users/23
        [HttpPost("workingtime/{id}")]
        public ActionResult AddCleanersWorkingTime([FromBody] WorkingTimeOutputModel workingTimeOutput,int id)
        {
            var workingTime = _autoMapper.Map<WorkingTimeModel>(workingTimeOutput);
            _userService.AddWorkingTime(workingTime,id);
            return StatusCode(StatusCodes.Status201Created, workingTime);
        }

        //api/Users/23
        [HttpPatch("{id}")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult RestoreUser(int id)
        {
            _userService.RestoreUserById(id);
            return Ok($"User with Id = {id} was restored");
        }

        private void CheckUser(UserModel userModel)
        {
            if (_userService.CheckIfLoginExists(userModel.Login))
                throw new AuthenticationException("Пользователь с таким логином уже существует");
            else if (_userService.CheckIfLoginExists(userModel.Email))
                throw new AuthenticationException("Пользователь с таким email уже существует");
        }
    }
}
