using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeEnum(Role.Admin)]
    public class CleaningTypeController : ControllerBase
    {
        private readonly ICleaningTypeService _cleaningTypeService;
        private readonly IMapper _autoMapperInstance;

        public CleaningTypeController(ICleaningTypeService cleaningTypeService, IMapper mapper)
        {
            _cleaningTypeService = cleaningTypeService;
            _autoMapperInstance = mapper;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CleaningAdditionOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CleaningTypeOutputModel> GetCleaningTypeById(int id)
        {
            var model = _cleaningTypeService.GetCleaningTypeById(id);
            var output = _autoMapperInstance.Map<CleaningTypeOutputModel>(model);
            return Ok(output);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<CleaningAdditionOutputModel>), StatusCodes.Status200OK)]
        public ActionResult<List<CleaningTypeOutputModel>> GetAllCleaningTypes()
        {
            var models = _cleaningTypeService.GetAllCleaningTypes();
            var output = _autoMapperInstance.Map<List<CleaningTypeOutputModel>>(models);
            return Ok(output);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult AddCleaningType([FromBody]CleaningTypeInsertInputModel cleaningTypeInsertInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningTypeModel>(cleaningTypeInsertInputModel);
            _cleaningTypeService.AddCleaningType(model);
            return StatusCode(StatusCodes.Status201Created, cleaningTypeInsertInputModel);
        }

        [HttpPut("{id}/cleaning-additions")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult AddCleaningAdditionToCleaningType(int id, int cleaningAdditionId)
        { 
            _cleaningTypeService.AddCleaningAdditionToCleaningType(id, cleaningAdditionId);
            return Ok();

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult UpdateCleaningType(int id, [FromBody]CleaningTypeUpdateInputModel cleaningTypeUpdateInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningTypeModel>(cleaningTypeUpdateInputModel);
            _cleaningTypeService.UpdateCleaningType(id, model);
            return Ok($"Cleaning type with {id} was updated");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCleaningType(int id)
        {
            _cleaningTypeService.DeleteCleaningType(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult RestoreCleaningType(int id)
        {
            _cleaningTypeService.RestoreCleaningType(id);
            return NoContent();
        }

        [HttpDelete("{id}/cleaning-additions")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult DeleteCleaningAdditionFromCleaningType(int id, int cleaningAdditionId)
        {
            _cleaningTypeService.DeleteCleaningAdditionFromCleaningType(id, cleaningAdditionId);
            return NoContent();
        }
    }
}
