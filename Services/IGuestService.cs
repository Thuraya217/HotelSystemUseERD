using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Services
{
    public interface IGuestService
    {
        void AddGuest(Guest guest);
        void DeleteGuest(string guestId);
        List<Guest> GetAllGuests();
        Guest GetGuestById(string guestId);
        void UpdateGuest(Guest guest);
    }
}