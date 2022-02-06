using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Services;
using AutoMapper;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        //[HttpGet("{id}")]
        //public ActionResult<UserInputModel> GetUserById(int id)
        //{
        //    var model = _cleaningAdditionService.GetCleaningAdditionById(id);
        //    var output = _autoMapperInstance.Map<CleaningAdditionOutputModel>(model);
        //    return Ok(output);
        //}

        //[HttpGet]
        //public ActionResult<List<UserModel>> GetAdmins()
        //{
        //    var admins = _userService.GetAllAdmins();
        //    return Ok(new List<UserModel> { new UserModel() });
        //}

        //[HttpGet]
        //public ActionResult<List<UserModel>> GetCleaners()
        //{
        //    return Ok(new List<UserModel> { new UserModel() });
        //}

        //[HttpGet]
        //public ActionResult<List<UserModel>> GetClients()
        //{
        //    return Ok(new List<UserModel> { new UserModel() });
        //}

        //[HttpPost]
        //public ActionResult AddAdmin(UserModel userModel)
        //{
        //    return StatusCode(StatusCodes.Status201Created, userModel);
        //}

        //[HttpPost]
        //public ActionResult AddCleaner(UserModel userModel)
        //{
        //    return StatusCode(StatusCodes.Status201Created, userModel);
        //}

        //[HttpPost]
        //public ActionResult AddClient(UserModel userModel)
        //{
        //    return StatusCode(StatusCodes.Status201Created, userModel);
        //}

        //[HttpPut()]
        //public ActionResult UpdateAdmin(int id, CleaningAdditionModel cleaningAdditionModel)
        //{
        //    return Ok($"Cleaning type with {id} was updated");
        //}

        //[HttpPut()]
        //public ActionResult UpdateCleaner(int id, CleaningAdditionModel cleaningAdditionModel)
        //{
        //    return Ok($"Cleaning type with {id} was updated");
        //}

        //[HttpPut()]
        //public ActionResult UpdateClient(int id, CleaningAdditionModel cleaningAdditionModel)
        //{
        //    return Ok($"Cleaning type with {id} was updated");
        //}


        //[HttpPatch()]
        //public ActionResult DeleteAdmin(int id, CleaningAdditionModel cleaningAdditionModel)
        //{
        //    return Accepted($"Cleaning type with {id} was deleted");
        //}

        //[HttpPatch("{id}")]
        //public ActionResult RestoreAdmin(int id, CleaningAdditionModel cleaningAdditionModel)
        //{
        //    return Accepted($"Cleaning type with {id} was deleted");
        //}
    }
}
