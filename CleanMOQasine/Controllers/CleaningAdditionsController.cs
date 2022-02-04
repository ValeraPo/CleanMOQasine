using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.API.Configurations;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningAdditionsController : ControllerBase
    {
        private readonly CleaningAdditionService _cleaningAdditionService;

        public CleaningAdditionsController()
        {
            _cleaningAdditionService = new();
        }

        //api/CleaningAdditions/228
        [HttpGet("{id}")]
        public ActionResult<CleaningAdditionOutputModel> GetCleaningAdditionById(int id)
        {
            var model = _cleaningAdditionService.GetCleaningAdditionById(id);
            var output = AutoMapperFromApi.GetInstance().Map<CleaningAdditionOutputModel>(model);
            return Ok(output);
        }

        //api/CleaningAdditions
        [HttpGet()]
        public ActionResult<List<CleaningAdditionOutputModel>> GetAllCleaningAdditions()
        {
            var models = _cleaningAdditionService.GetAllCleaningAdditions();
            var outputs = AutoMapperFromApi.GetInstance().Map<List<CleaningAdditionOutputModel>>(models);
            return Ok(outputs);
        }

        //api/CleaningAdditions
        [HttpPost]
        public ActionResult<CleaningAdditionOutputModel> AddCleaningAddition([FromBody]CleaningAdditionInputModel cleaningAdditionInputModel)
        {
            var model = AutoMapperFromApi.GetInstance().Map<CleaningAdditionModel>(cleaningAdditionInputModel);
            model.Duration = TimeSpan.Parse(cleaningAdditionInputModel.Duration);
            _cleaningAdditionService.AddCleaningAddition(model);
            return StatusCode(StatusCodes.Status201Created, cleaningAdditionInputModel);
        }

        //api/CleaningAdditions/228
        [HttpPut("{id}")]
        public ActionResult UpdateCleaningAddition(int id, [FromBody] CleaningAdditionInputModel cleaningAdditionInputModel)
        {
            var model = AutoMapperFromApi.GetInstance().Map<CleaningAdditionModel>(cleaningAdditionInputModel);
            model.Duration = TimeSpan.Parse(cleaningAdditionInputModel.Duration);
            _cleaningAdditionService.UpdateCleaningAddition(id, model);
            return Ok($"Cleaning type with {id} was updated");
        }

        //api/CleaningAdditions/228-delete
        [HttpPatch("{id}-delete")]
        public ActionResult DeleteCleaningAddition(int id)
        {
            _cleaningAdditionService.DeleteCleaningAddition(id);
            return Ok($"Cleaning type with {id} was deleted");
        }

        //api/CleaningAdditions/228-restore
        [HttpPatch("{id}-restore")]
        public ActionResult RestoreCleaningAddition(int id)
        {
            _cleaningAdditionService.RestoreCleaningAddition(id);
            return Ok($"Cleaning type with {id} was restored");
        }

        
    }
}
