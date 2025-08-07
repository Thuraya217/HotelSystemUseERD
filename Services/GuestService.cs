using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;

namespace HotelSystemUseERD.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }


        public void AddGuest(Guest guest)
        {

            var existingGuests = _guestRepository.GetAllGuests();
            bool phoneExists = existingGuests.Any(g => g.PhoneNumber == guest.PhoneNumber);

            if (phoneExists)
            {
                Console.WriteLine("Phone number already exists for another guest.");
                return;
            }

            _guestRepository.AddGuest(guest);
        }

        public void UpdateGuest(Guest guest)
        {
            _guestRepository.UpdateGuest(guest);
        }

        public void DeleteGuest(string guestId)
        {
            _guestRepository.DeleteGuest(guestId);
        }

        public Guest GetGuestById(string guestId)
        {
            return _guestRepository.GetGuestById(guestId);
        }

        public List<Guest> GetAllGuests()
        {
            return _guestRepository.GetAllGuests();
        }
    }
}
