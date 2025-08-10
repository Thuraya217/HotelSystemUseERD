using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Services
{
    public interface IRoomService
    {
        void AddRoom(Room room);
        void DeleteRoom(string roomId);
        List<Room> GetAllRooms();
        List <Room> GetAvailableRooms();
        Room GetRoomById(string roomId);
        void SetAvailability(string roomId, bool isAvailable);
        void UpdateRoom(Room room);
    }
}