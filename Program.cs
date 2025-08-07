

using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;
using HotelSystemUseERD.Services;

namespace HotelSystemUseERD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new HotelDbContext();
            context.Database.EnsureCreated();

            // Repositories
            IGuestRepository guestRepo = new GuestRepository(context);
            IBookingRepository bookingRepo = new BookingRepository(context);
            IRoomRepository roomRepo = new RoomRepository(context);
            IReviewRepository reviewRepo = new ReviewRepository(context); 

            // Services
            GuestService guestService = new GuestService(guestRepo);
            BookingService bookingService = new BookingService(bookingRepo);
            RoomService roomService = new RoomService(roomRepo);
            ReviewService reviewService = new ReviewService(reviewRepo);

            // Add some test data
            Console.WriteLine("== Creating Guests ==");
            guestService.AddGuest(new Guest { GuestId = "G001", GuestName = "Sarah", PhoneNumber = "99887766" });
            guestService.AddGuest(new Guest { GuestId = "G002", GuestName = "Ali", PhoneNumber = "99112233" });

            Console.WriteLine("== Creating Rooms ==");
            roomService.AddRoom(new Room { RoomId = "R101", RoomType = "Single", Price = 50, IsAvailable = true });
            roomService.AddRoom(new Room { RoomId = "R102", RoomType = "Double", Price = 75, IsAvailable = true });

            Console.WriteLine("== Creating Booking ==");
            bookingService.AddBooking(new Booking
            {
                BookingId = "B001",
                GuestId = "G001",
                RoomId = "R101",
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(3)
            });

            // Display Bookings
            Console.WriteLine("\n== All Bookings ==");
            var bookings = bookingService.GetAllBookings();
            foreach (var booking in bookings)
            {
                Console.WriteLine($"BookingId: {booking.BookingId}, Guest: {booking.GuestId}, Room: {booking.RoomId}, From: {booking.CheckInDate.ToShortDateString()} To: {booking.CheckOutDate.ToShortDateString()}");
            }

        }
    }
}
