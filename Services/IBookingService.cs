using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Services
{
    public interface IBookingService
    {
        void AddBooking(Booking booking);
        void DeleteBooking(string bookingId);
        List<Booking> GetAllBookings();
        void UpdateBooking(Booking booking);
    }
}