using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IRoomService
    {
        void AddRoom(RoomModel roomModel);
        void DeleteRoomById(int id);
        List<RoomModel> GetAllRooms();
        RoomModel GetRoomById(int id);
        void RestoreRoomById(int id);
        void UpdateRoom(int id, RoomModel roomModel);
    }
}