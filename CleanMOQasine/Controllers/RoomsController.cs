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
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("The controller is used to interact with rooms")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _autoMapper;

        public RoomsController(IRoomService roomService, IMapper autoMapper)
        {
            _roomService = roomService;
            _autoMapper = autoMapper;
        }

        //api/Rooms/23
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(RoomOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get a room by id. Roles: All.")]
        public ActionResult<RoomOutputModel> GetRoomById(int id)
        {
            var roomModel = _roomService.GetRoomById(id);

            if (roomModel is null)
                return NotFound($"Room with Id = {id} was not found");

            var output = _autoMapper.Map<RoomOutputModel>(roomModel);
            return Ok(output);
        }

        //api/Rooms
        [HttpGet()]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<RoomOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation("Get all rooms. Roles: All.")]
        public ActionResult<List<RoomOutputModel>> GetAllRooms()
        {
            var roomModels = _roomService.GetAllRooms();
            var outputs = _autoMapper.Map<List<RoomOutputModel>>(roomModels);
            return Ok(outputs);
        }

        //api/Rooms/23
        [HttpPut("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Update a room. Roles: Admin.")]
        public ActionResult UpdateRoom(int id, [FromBody] RoomInputModel roomInputModel)
        {
            var roomModel = _autoMapper.Map<RoomModel>(roomInputModel);
            _roomService.UpdateRoom(id, roomModel);
            return Ok($"Room with Id = {id} was updated");
        }

        //api/Rooms
        [HttpPost]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(RoomOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Add a brand new room. Roles: Admin.")]
        public ActionResult<RoomOutputModel> AddRoom([FromBody] RoomInputModel roomInputModel)
        {
            var roomModel = _autoMapper.Map<RoomModel>(roomInputModel);
            _roomService.AddRoom(roomModel);
            return StatusCode(StatusCodes.Status201Created, roomModel);
        }

        //api/Rooms/23
        [HttpDelete("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete a room. Roles: Admin.")]
        public ActionResult DeleteRoom(int id)
        {
            _roomService.DeleteRoomById(id);
            return NoContent();
        }

        //api/Rooms/23
        [HttpPatch("{id}")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Restore a room. Roles: Admin.")]
        public ActionResult RestoreRoom(int id)
        {
            _roomService.RestoreRoomById(id);
            return Ok($"Room with Id = {id} was restored");
        }
    }
}
