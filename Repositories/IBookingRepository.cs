using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void DeleteBooking(string bookingId);
        List<Booking> GetAllBookings();
        void UpdateBooking(Booking booking);
    }
}