using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;

namespace HotelSystemUseERD.Services
{
    class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void AddRoom(Room room)
        {
            if (string.IsNullOrWhiteSpace(room.RoomId) || string.IsNullOrWhiteSpace(room.RoomType))
            {
                Console.WriteLine("Room ID and Room Type are required.");
                return;
            }

            if (_roomRepository.GetRoomById(room.RoomId) != null)
            {
                Console.WriteLine("Room with the same ID already exists.");
                return;
            }

            _roomRepository.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(string roomId)
        {
            var room = _roomRepository.GetRoomById(roomId);
            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            _roomRepository.DeleteRoom(roomId);
        }

        public Room GetRoomById(string roomId)
        {
            return _roomRepository.GetRoomById(roomId);
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public List<Room> GetAvailableRooms()
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
