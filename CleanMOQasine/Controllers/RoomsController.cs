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
    [ApiController]
    [Route("api/[controller]")]
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
        [Authorize]
        public ActionResult<List<RoomOutputModel>> GetAllRooms()
        {
            var roomModels = _roomService.GetAllRooms();
            var outputs = _autoMapper.Map<List<RoomOutputModel>>(roomModels);
            return Ok(outputs);
        }

        //api/Rooms/23
        [HttpPut("{id}")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult UpdateRoom(int id, [FromBody] RoomInputModel roomInputModel)
        {
            var roomModel = _autoMapper.Map<RoomModel>(roomInputModel);
            _roomService.UpdateRoom(id, roomModel);
            return Ok($"Room with Id = {id} was updated");
        }

        //api/Rooms
        [HttpPost]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult<RoomModel> AddRoom([FromBody] RoomInputModel roomInputModel)
        {
            var roomModel = _autoMapper.Map<RoomModel>(roomInputModel);
            _roomService.AddRoom(roomModel);
            return StatusCode(StatusCodes.Status201Created, roomModel);
        }

        //api/Rooms/23
        [HttpDelete("{id}")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult DeleteRoom(int id)
        {
            _roomService.DeleteRoomById(id);
            return NoContent();
        }

        //api/Rooms/23
        [HttpPatch("{id}")]
        [AuthorizeEnum(Role.Admin)]
        public ActionResult RestoreRoom(int id)
        {
            _roomService.RestoreRoomById(id);
            return Ok($"Room with Id = {id} was restored");
        }
    }
}
