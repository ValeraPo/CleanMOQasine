using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<UserOutputModel> GetUserById(int id)
        {
            var userModel = _userService.GetUserById(id);

            if (userModel is null)
                return NotFound($"User with Id = {id} was not found");

            var output = _autoMapper.Map<UserOutputModel>(userModel);
            return Ok(output);
        }

        //api/Users
        [HttpGet("admins")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult<List<UserOutputModel>> GetAllAdmins()
        {
            var userModels = _userService.GetAllAdmins();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet("cleaners")]
        public ActionResult<List<UserOutputModel>> GetAllCleaners()
        {
            var userModels = _userService.GetAllCleaners();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet("clients")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult<List<UserOutputModel>> GetAllCLients()
        {
            var userModels = _userService.GetAllClients();
            var outputs = _autoMapper.Map<List<UserOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users/23
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateInputModel userUpdateInputModel)
        {
            var userModel = _autoMapper.Map<UserModel>(userUpdateInputModel);
            _userService.UpdateUser(id, userModel);
            return Ok($"User with Id = {id} was updated");
        }

        //api/Users
        [HttpPost("clients")]
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
