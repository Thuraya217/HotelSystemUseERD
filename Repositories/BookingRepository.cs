using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystemUseERD.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystemUseERD.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _context;

        public BookingRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(string bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            else
            {
                 Console.WriteLine($"Booking with ID {bookingId} not found.");
            }
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public List <Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

    }
}
