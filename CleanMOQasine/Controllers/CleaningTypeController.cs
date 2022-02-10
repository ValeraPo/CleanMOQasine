using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using AutoMapper;
using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Models;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningTypeController : ControllerBase
    {
        private readonly ICleaningTypeService _cleaningTypeService;
        private readonly ICleaningAdditionService _cleaningAdditionService;
        private readonly IMapper _autoMapperInstance;

        public CleaningTypeController(ICleaningTypeService cleaningTypeService, 
            ICleaningAdditionService cleaningAdditionService,
            IMapper mapper)
        {
            _cleaningTypeService = cleaningTypeService;
            _cleaningAdditionService = cleaningAdditionService;
            _autoMapperInstance = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<CleaningTypeOutputModel> GetCleaningTypeById(int id)
        {
            var model = _cleaningTypeService.GetCleaningTypeById(id);
            var output = _autoMapperInstance.Map<CleaningTypeOutputModel>(model);
            return Ok(output);
        }

        [HttpGet]
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

        [HttpPut("{cleaningTypeId}/cleaning-additions")]
        public ActionResult AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId)
        { 
            _cleaningTypeService.AddCleaningAdditionToCleaningType(cleaningTypeId, cleaningAdditionId);
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
    }
}
