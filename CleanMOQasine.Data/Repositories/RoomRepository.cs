using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class RoomRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public RoomRepository() => _dbContext = CleanMOQasineContext.GetInstance();

        public Room? GetRoomById(int id) => _dbContext.Room.Include(r => r.Orders).FirstOrDefault(r => r.Id == id);

        public List<Room> GetRooms() => _dbContext.Room.Where(r => !r.IsDeleted).ToList();

        public void AddRoom(Room room)
        {
            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            var entity = GetRoomById(room.Id);
            entity.Name = room.Name;
            entity.Price = room.Price;
            _dbContext.SaveChanges();
        }

        public void UpdateRoom(int id, bool isDeleted)
        {
            var room = _dbContext.Room.FirstOrDefault(r => r.Id == id);
            room.IsDeleted = isDeleted;
            _dbContext.SaveChanges();
        }
    }
}
