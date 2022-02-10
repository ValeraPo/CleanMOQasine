using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningTypeController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<CleaningTypeModel> GetCleaningAdditionById(int id)
        {
            return Ok(new CleaningTypeModel());
        }

        [HttpGet]
        public ActionResult<List<CleaningTypeModel>> GetAllCleaningAdditions()
        {
            return Ok(new List<CleaningTypeModel> { new CleaningTypeModel() });
        }

        [HttpPost]
        public ActionResult AddCleaningAddition(CleaningTypeModel cleaningTypeModel)
        {
            return StatusCode(StatusCodes.Status201Created, cleaningTypeModel);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCleaningAddition(int id, CleaningTypeModel cleaningTypeModel)
        {
            return Ok($"Cleaning type with {id} was updated");
        }


        [HttpPatch]
        public ActionResult DeleteCleaningAddition(int id, CleaningTypeModel cleaningTypeModel)
        {
            return Accepted($"Cleaning type with {id} was deleted");
        }

        [HttpPatch("{id}")]
        public ActionResult RestoreCleaningAddition(int id, CleaningTypeModel cleaningTypeModel)
        {
            return Accepted($"Cleaning type with {id} was deleted");
        }
    }
}
