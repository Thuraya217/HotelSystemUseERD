using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;

namespace HotelSystemUseERD.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void AddRoom(Room room)
        {
            
            _roomRepository.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(string roomId)
        {
            _roomRepository.DeleteRoom(roomId);
        }

        public Room GetRoomById(string roomId)
        {
            return _roomRepository.GetRoomById(roomId);
        }

        public List <Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public List <Room> GetAvailableRooms()
        {
            return _roomRepository.GetAllRooms()
                .Where(r => r.IsAvailable)
                .ToList();
        }

        public void SetAvailability(string roomId, bool isAvailable)
        {
            var room = _roomRepository.GetRoomById(roomId);
            if (room != null)
            {
                room.IsAvailable = isAvailable;
                _roomRepository.UpdateRoom(room);
            }
        }
    }
}
