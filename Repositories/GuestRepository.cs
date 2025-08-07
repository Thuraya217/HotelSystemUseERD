using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _context;

        public GuestRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
        }

        public void UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest);
            _context.SaveChanges();
        }

        public void DeleteGuest(string guestId)
        {
            var guest = _context.Guests.FirstOrDefault(g => g.GuestId == guestId);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
            }
        }

        public Guest GetGuestById(string guestId)
        {
            return _context.Guests.FirstOrDefault(g => g.GuestId == guestId);
        }

        public List<Guest> GetAllGuests()
        {
            return _context.Guests.ToList();
        }
    }
}
