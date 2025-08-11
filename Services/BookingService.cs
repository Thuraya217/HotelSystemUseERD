using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void AddBooking(Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }

        public void DeleteBooking(string bookingId)
        {
            _bookingRepository.DeleteBooking(bookingId);
        }

        public List<Booking> GetBookingsByGuestId(string guestId)
        {
            return _bookingRepository.GetAllBookings().Where(b => b.GuestId == guestId).ToList();
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }
    }
}
 
