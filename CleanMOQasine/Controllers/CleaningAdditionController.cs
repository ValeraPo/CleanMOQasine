using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningAdditionController : ControllerBase
    {

        [HttpGet("Get by Id")]
        public ActionResult<CleaningAdditionModel> GetCleaningAdditionById(int id)
        {
            return Ok(new CleaningAdditionModel());
        }

        [HttpGet]
        public ActionResult<List<CleaningAdditionModel>> GetAllCleaningAdditions()
        {
            return Ok(new List<CleaningAdditionModel> { new CleaningAdditionModel() });
        }

        [HttpPost]
        public ActionResult AddCleaningAddition(CleaningAdditionModel cleaningAdditionModel)
        {
            return StatusCode(StatusCodes.Status201Created, cleaningAdditionModel);
        }

        [HttpPut("Update by Id")]
        public ActionResult UpdateCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel)
        {
            return Ok($"Cleaning type with {id} was updated");
        }


        [HttpPatch("Delete by Id")]
        public ActionResult DeleteCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel)
        {
            return Accepted($"Cleaning type with {id} was deleted");
        }

        [HttpPatch("Restore by {id}")]
        public ActionResult RestoreCleaningAddition(int id, CleaningAdditionModel cleaningAdditionModel)
        {
            return Accepted($"Cleaning type with {id} was deleted");
        }

    }
}
