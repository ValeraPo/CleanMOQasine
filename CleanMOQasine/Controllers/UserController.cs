using AutoMapper;
using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly Mapper _autoMapperInstance;

        public UserController()
        {
            _userService = new UserService();
            _autoMapperInstance = AutoMapperFromApi.GetInstance();
        }

        //api/Users/23
        [HttpGet("{id}")]
        public ActionResult<UserOutputModel> GetUserById(int id)
        {
            var model = _userService.GetUserById(id);
            var output = _autoMapperInstance.Map<UserOutputModel>(model);
            return Ok(output);
        }

        //api/CleaningAdditions
        [HttpGet()]
        public ActionResult<List<CleaningAdditionOutputModel>> GetAllCleaningAdditions()
        {
            var models = _userService.GetAllCleaningAdditions();
            var outputs = _autoMapperInstance.Map<List<CleaningAdditionOutputModel>>(models);
            return Ok(outputs);
        }

        //api/CleaningAdditions
        [HttpPost]
        public ActionResult AddCleaningAddition([FromBody] CleaningAdditionInputModel cleaningAdditionInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningAdditionModel>(cleaningAdditionInputModel);
            _userService.AddCleaningAddition(model);
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/CleaningAdditions/228
        [HttpPut("{id}")]
        public ActionResult UpdateCleaningAddition(int id, [FromBody] CleaningAdditionInputModel cleaningAdditionInputModel)
        {
            var model = AutoMapperFromApi.GetInstance().Map<CleaningAdditionModel>(cleaningAdditionInputModel);
            _userService.UpdateCleaningAddition(id, model);
            return Ok($"Cleaning type with {id} was updated");
        }

        //api/CleaningAdditions/228
        [HttpDelete("{id}")]
        public ActionResult DeleteCleaningAddition(int id)
        {
            _userService.DeleteCleaningAddition(id);
            return Ok($"Cleaning type with {id} was deleted");
        }

        //api/CleaningAdditions/228
        [HttpPatch("{id}")]
        public ActionResult RestoreCleaningAddition(int id)
        {
            _userService.RestoreCleaningAddition(id);
            return Ok($"Cleaning type with {id} was restored");
        }
    }
}
