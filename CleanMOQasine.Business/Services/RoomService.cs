using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class RoomService
    {
        private readonly RoomRepository _roomRepository;

        public RoomService()
        {
            _roomRepository = new RoomRepository();
        }

        public List<RoomModel> GetAllAdmins()
        {
            var rooms = _roomRepository.GetRooms();
            return AutoMapperToData.GetInstance().Map<List<RoomModel>>(rooms);
        }
    }
}
