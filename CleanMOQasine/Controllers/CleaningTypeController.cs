using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Models;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningTypeController : ControllerBase
    {
        [HttpGet("Get by Id")]
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

        [HttpPut("Update by Id")]
        public ActionResult UpdateCleaningAddition(int id, CleaningTypeModel cleaningTypeModel)
        {
            return Ok($"Cleaning type with {id} was updated");
        }


        [HttpPatch("Delete by Id")]
        public ActionResult DeleteCleaningAddition(int id, CleaningTypeModel cleaningTypeModel)
        {
            return Accepted($"Cleaning type with {id} was deleted");
        }

        [HttpPatch("Restore by {id}")]
        public ActionResult RestoreCleaningAddition(int id, CleaningTypeModel cleaningTypeModel)
        {
            return Accepted($"Cleaning type with {id} was deleted");
        }
    }
}
