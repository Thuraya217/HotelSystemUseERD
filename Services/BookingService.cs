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
            var allBookings = _bookingRepository.GetAllBookings();

            bool isConflict = allBookings.Any(b =>
            b.RoomId == booking.RoomId &&
            (
                (booking.CheckInDate >= b.CheckInDate && booking.CheckInDate < b.CheckOutDate) ||
                (booking.CheckOutDate > b.CheckInDate && booking.CheckOutDate <= b.CheckOutDate)
            )
          );

            if (isConflict)
            {
                Console.WriteLine("Room is already booked in this time ");
            }
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

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }
    }
}
 
