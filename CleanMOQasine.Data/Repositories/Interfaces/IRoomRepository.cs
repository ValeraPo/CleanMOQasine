using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IRoomRepository
    {
        int AddRoom(Room room);
        Room? GetRoomById(int id);
        List<Room> GetRooms();
        void UpdateRoom(int id, bool isDeleted);
        void UpdateRoom(Room room);
    }
}