using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class RoomRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public RoomRepository() => _dbContext = CleanMOQasineContext.GetInstance();

        public Room GetRoomById(int id) => _dbContext.Room.Include(r => r.Orders).FirstOrDefault(r => r.Id == id);

        public List<Room> GetAllRooms() => _dbContext.Room.Include(r => r.Orders).ToList();

        public List<Room> GetRoomsByOrders(Order order) => _dbContext.Room.Where(r => r.Orders.Contains(order)).Include(r => r.Orders).ToList();

        public void AddRoom(Room room)
        {
            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();
        }

        public void UpdateRoom(Room updatedRoom)
        {
            var room = GetRoomById(updatedRoom.Id);
            room = updatedRoom;
            _dbContext.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = _dbContext.Room.FirstOrDefault(r => r.Id == id);
            room.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public void RestoreRoom(int id)
        {
            var room = _dbContext.Room.FirstOrDefault(r => r.Id == id);
            room.IsDeleted = false;
            _dbContext.SaveChanges();
        }
    }
}
