using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _autoMapper;

        public RoomService(IRoomRepository roomRepository, IMapper autoMapper)
        {
            _roomRepository = roomRepository;
            _autoMapper = autoMapper;
        }

        public RoomModel GetRoomById(int id)
        {
            var room = _roomRepository.GetRoomById(id);
            CheckRoom(room, id);
            return _autoMapper.Map<RoomModel>(room);
        }

        public List<RoomModel> GetAllRooms()
        {
            var rooms = _roomRepository.GetRooms();
            return _autoMapper.Map<List<RoomModel>>(rooms);
        }

        public void AddRoom(RoomModel roomModel)
        {
            var mappedRoom = _autoMapper.Map<Room>(roomModel);
            _roomRepository.AddRoom(mappedRoom);
        }

        public void UpdateRoom(int id, RoomModel roomModel)
        {
            var room = _roomRepository.GetRoomById(id);
            CheckRoom(room, id);
            var mappedRoom = _autoMapper.Map<Room>(roomModel);
            _roomRepository.UpdateRoom(mappedRoom);
        }

        public void DeleteRoomById(int id)
        {
            var room = _roomRepository.GetRoomById(id);
            CheckRoom(room, id);
            _roomRepository.UpdateRoom(id, true);
        }

        public void RestoreRoomById(int id)
        {
            var room = _roomRepository.GetRoomById(id);
            CheckRoom(room, id);
            _roomRepository.UpdateRoom(id, false);
        }

        private void CheckRoom(Room room, int id)
        {
            if (room is null)
                throw new Exception($"Комната с id = {id} не найдена");
        }

    }
}
