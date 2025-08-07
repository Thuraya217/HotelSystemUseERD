using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    internal interface IRoomRepository
    {
        void AddRoom(Room room);
        void DeleteRoom(string roomId);
        List<Room> GetAllRooms();
        Room GetRoomById(string roomId);
        void UpdateRoom(Room room);
    }
}