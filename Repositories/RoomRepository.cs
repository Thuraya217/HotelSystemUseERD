using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(string roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Room with ID {roomId} not found.");
            }
        }

        public Room GetRoomById(string roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        public List <Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }
    }
}
