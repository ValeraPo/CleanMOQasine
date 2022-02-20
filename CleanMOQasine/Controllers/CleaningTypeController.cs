using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using AutoMapper;
using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Models;
using CleanMOQasine.Data.Enums;
using CleanMOQasine.API.Attributes;
using Microsoft.AspNetCore.Authorization;

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
        public ActionResult<CleaningTypeOutputModel> GetCleaningTypeById(int id)
        {
            var model = _cleaningTypeService.GetCleaningTypeById(id);
            var output = _autoMapperInstance.Map<CleaningTypeOutputModel>(model);
            return Ok(output);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<CleaningTypeOutputModel>> GetAllCleaningTypes()
        {
            var models = _cleaningTypeService.GetAllCleaningTypes();
            var output = _autoMapperInstance.Map<List<CleaningTypeOutputModel>>(models);
            return Ok(output);
        }

        [HttpPost]
        public ActionResult AddCleaningType([FromBody]CleaningTypeInsertInputModel cleaningTypeInsertInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningTypeModel>(cleaningTypeInsertInputModel);
            _cleaningTypeService.AddCleaningType(model);
            return StatusCode(StatusCodes.Status201Created, cleaningTypeInsertInputModel);
        }

        [HttpPut("{id}/cleaning-additions")]
        public ActionResult AddCleaningAdditionToCleaningType(int id, int cleaningAdditionId)
        { 
            _cleaningTypeService.AddCleaningAdditionToCleaningType(id, cleaningAdditionId);
            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult UpdateCleaningType(int id, [FromBody]CleaningTypeUpdateInputModel cleaningTypeUpdateInputModel)
        {
            var model = _autoMapperInstance.Map<CleaningTypeModel>(cleaningTypeUpdateInputModel);
            _cleaningTypeService.UpdateCleaningType(id, model);
            return Ok($"Cleaning type with {id} was updated");
        }


        [HttpDelete]
        public ActionResult DeleteCleaningType(int id)
        {
            _cleaningTypeService.DeleteCleaningType(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult RestoreCleaningType(int id)
        {
            _cleaningTypeService.RestoreCleaningType(id);
            return NoContent();
        }

        [HttpDelete("{id}/cleaning-additions")]
        public ActionResult DeleteCleaningAdditionFromCleaningType(int id, int cleaningAdditionId)
        {
            _cleaningTypeService.DeleteCleaningAdditionFromCleaningType(id, cleaningAdditionId);
            return NoContent();
        }
    }
}
