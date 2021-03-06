using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public RoomRepository(CleanMOQasineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room? GetRoomById(int id) => _dbContext.Rooms.Include(r => r.Orders).FirstOrDefault(r => r.Id == id);

        public List<Room> GetRooms() => _dbContext.Rooms.Where(r => !r.IsDeleted).ToList();

        public int AddRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
            return room.Id;
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
            var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == id);
            room.IsDeleted = isDeleted;
            _dbContext.SaveChanges();
        }
    }
}
