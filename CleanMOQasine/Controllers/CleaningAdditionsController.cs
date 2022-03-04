using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeEnum(Role.Admin)]
    public class CleaningAdditionsController : ControllerBase
    {
        private readonly ICleaningAdditionService _cleaningAdditionService;
        private readonly IMapper _autoMapperInstance;

        public CleaningAdditionsController(ICleaningAdditionService cleaningAdditionService, IMapper mapper)
        {
            _cleaningAdditionService = cleaningAdditionService;
            _autoMapperInstance = mapper;
        }

        //api/CleaningAdditions/228
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CleaningAdditionOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CleaningAdditionOutputModel> GetCleaningAdditionById(int id)
        {
            var model = _cleaningAdditionService.GetCleaningAdditionById(id);
            var output = _autoMapperInstance.Map<CleaningAdditionOutputModel>(model);
            return Ok(output);
        }

        //api/CleaningAdditions
        [HttpGet()]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<CleaningAdditionOutputModel>), StatusCodes.Status200OK)]
        public ActionResult<List<CleaningAdditionOutputModel>> GetAllCleaningAdditions()
        {
            var models = _cleaningAdditionService.GetAllCleaningAdditions();
            var outputs = _autoMapperInstance.Map<List<CleaningAdditionOutputModel>>(models);
            return Ok(outputs);
        }

        //api/CleaningAdditions
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult AddCleaningAddition([FromBody] CleaningAdditionInputModel cleaningAdditionInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningAdditionModel>(cleaningAdditionInputModel);
            _cleaningAdditionService.AddCleaningAddition(model);
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/CleaningAdditions/228
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult UpdateCleaningAddition(int id, [FromBody] CleaningAdditionInputModel cleaningAdditionInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningAdditionModel>(cleaningAdditionInputModel);
            _cleaningAdditionService.UpdateCleaningAddition(id, model);
            return Ok($"Cleaning type with {id} was updated");
        }

        //api/CleaningAdditions/228
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCleaningAddition(int id)
        {
            _cleaningAdditionService.DeleteCleaningAddition(id);
            return Ok($"Cleaning type with {id} was deleted");
        }

        //api/CleaningAdditions/228
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult RestoreCleaningAddition(int id)
        {
            _cleaningAdditionService.RestoreCleaningAddition(id);
            return Ok($"Cleaning type with {id} was restored");
        }


    }
}