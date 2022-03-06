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
        [SwaggerOperation("Get cleaning type by id with not deleted cleaning additions. Roles: all and anonymus.")]
        public ActionResult<CleaningTypeOutputModel> GetCleaningTypeById(int id)
        {
            var model = _cleaningTypeService.GetCleaningTypeById(id);
            var output = _autoMapperInstance.Map<CleaningTypeOutputModel>(model);
            return Ok(output);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<CleaningAdditionOutputModel>), StatusCodes.Status200OK)]
        [SwaggerOperation("Get all cleaning types with not deleted cleaning additions. Roles: all and anonymus.")]
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
        [SwaggerOperation("Add cleaning type. Roles: Admin.")]
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
        [SwaggerOperation("Add cleaning addition to cleaning type. Create row in link table \"CleaningAdditionCleaningType\". Roles: Admin.")]
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
        [SwaggerOperation("Update cleaning cleaning type. Roles: Admin.")]
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
        [SwaggerOperation("Soft delete cleaning cleaning type. Roles: Admin.")]
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
        [SwaggerOperation("Restore cleaning cleaning type. Roles: Admin.")]
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
        [SwaggerOperation("Delete cleaning addition from cleaning type. Hard delete row from link table \"CleaningAdditionCleaningType\". Roles: Admin.")]
        public ActionResult DeleteCleaningAdditionFromCleaningType(int id, int cleaningAdditionId)
        {
            _cleaningTypeService.DeleteCleaningAdditionFromCleaningType(id, cleaningAdditionId);
            return NoContent();
        }
    }
}
