using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    public interface IGuestRepository
    {
        void AddGuest(Guest guest);
        void DeleteGuest(string guestId);
        List<Guest> GetAllGuests();
        Guest GetGuestById(string guestId);
        void UpdateGuest(Guest guest);
    }
}