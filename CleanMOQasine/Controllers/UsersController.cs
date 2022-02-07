using AutoMapper;
using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly Mapper _autoMapperInstance;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _autoMapperInstance = AutoMapperFromApi.GetInstance();
        }

        //api/Users/23
        [HttpGet("{id}")]
        public ActionResult<UserOutputModel> GetUserById(int id)
        {
            var userModel = _userService.GetUserById(id);

            if (userModel is null)
                return NotFound($"User with Id = {id} was not found");

            var output = _autoMapperInstance.Map<UserOutputModel>(userModel);
            return Ok(output);
        }

        //api/Users
        [HttpGet()]
        public ActionResult<List<UserOutputModel>> GetAllAdmins()
        {
            var userModels = _userService.GetAllAdmins();
            var outputs = _autoMapperInstance.Map<List<CleaningAdditionOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet()]
        public ActionResult<List<UserOutputModel>> GetAllCleaners()
        {
            var userModels = _userService.GetAllCleaners();
            var outputs = _autoMapperInstance.Map<List<CleaningAdditionOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users
        [HttpGet()]
        public ActionResult<List<UserOutputModel>> GetAllCLients()
        {
            var userModels = _userService.GetAllClients();
            var outputs = _autoMapperInstance.Map<List<CleaningAdditionOutputModel>>(userModels);
            return Ok(outputs);
        }

        //api/Users/23
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateInputModel userUpdateInputModel)
        {
            var userModel = _autoMapperInstance.Map<UserModel>(userUpdateInputModel);
            _userService.UpdateUser(id, userModel);
            return Ok($"User with Id = {id} was updated");
        }

        //api/Users
        [HttpPost]
        public ActionResult<UserModel> AddUser(UserInsertInputModel userInsertInputModel)
        {
            var userModel = _autoMapperInstance.Map<UserModel>(userInsertInputModel);
            _userService.AddUser(userModel);
            return StatusCode(StatusCodes.Status201Created, userModel);
        }

        //api/Users/23/Orders
        [HttpPut("{id}/orders")]
        public ActionResult<OrderModel> AddOrderToUser(UserUpdateOrderInputModel order, int userId)
        {
            _userService.AddOrderToUser(order.OrderId, userId);
            return Ok($"Order with Id = {order.OrderId} was added to User with Id = {userId}");
        }

        //api/Users/23
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUserById(id);
            return NoContent();
        }

        //api/Users/23
        [HttpPatch("{id}")]
        public ActionResult RestoreUser(int id)
        {
            _userService.RestoreUserById(id);
            return Ok($"User with Id = {id} was restored");
        }
    }
}
