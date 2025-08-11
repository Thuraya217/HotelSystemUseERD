

using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;
using HotelSystemUseERD.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HotelSystemUseERD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new HotelDbContext())
            {
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


                bool running = true;
                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("  Welcome to Hotel, Select Option:  ");
                    Console.WriteLine("1. Admin Menu");
                    Console.WriteLine("2. User Menu");
                    Console.WriteLine("0. Exit");
                    Console.Write("Choose option: ");


                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AdminMenu(roomService, bookingService);
                            break;

                        case "2":
                            UserMenu(guestService, roomService, bookingService);
                            break;

                        case "0":
                            running = false;
                            Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Press any key to try again.");
                            Console.ReadKey();
                            break;
                    }
                }

                static void AdminMenu(IRoomService roomService, IBookingService bookingService)
                {

                    if (!AdminLogin())
                    {
                        Console.WriteLine("Invalid admin name or password. Returning to main menu...");
                        Console.ReadKey();
                        return;
                    }

                    bool adminRunning = true;
                    while (adminRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Admin Menu ===");
                        Console.WriteLine("1. Add Room");
                        Console.WriteLine("2. View All Rooms");
                        Console.WriteLine("3. Delete Room");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Choose option: ");

                        string adminChoice = Console.ReadLine();
                        switch (adminChoice)
                        {
                            case "1":
                                AddRoom(roomService);
                                break;

                            case "2":
                                ViewRooms(roomService);
                                break;

                            case "3":
                                DeleteRoom(roomService);
                                break;

                            case "0":
                                adminRunning = false;
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Press any key.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }

                static void UserMenu(IGuestService guestService, IRoomService roomService, IBookingService bookingService)
                {
                    Console.Clear();
                    Console.WriteLine("=== User Registration ===");
                    Console.Write("Enter your Guest ID: ");
                    string guestId = Console.ReadLine();

                    var guest = guestService.GetGuestById(guestId);
                    if (guest == null)
                    {
                        Console.WriteLine("Guest not found, creating new guest.");
                        Console.Write("Enter your Name: ");
                        string guestName = Console.ReadLine();

                        Console.Write("Enter your Phone Number: ");
                        string phone = Console.ReadLine();

                        guest = new Guest
                        {
                            GuestId = guestId,
                            GuestName = guestName,
                            PhoneNumber = phone
                        };

                        guestService.AddGuest(guest);
                        Console.WriteLine($"Guest created successfully. name: {guest.GuestName}, ID: {guest.GuestId}!");
                    }
                    else
                    {
                        Console.WriteLine($"Welcome back, {guest.GuestName}!");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    bool userRunning = true;
                    while (userRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("=== User Menu ===");
                        Console.WriteLine("1. Book Room");
                        Console.WriteLine("2. View My Bookings");
                        Console.WriteLine("3. Cancel Booking");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Choose option: ");

                        string userChoice = Console.ReadLine();
                        switch (userChoice)
                        {
                            case "1":
                                BookRoom(guest, roomService, bookingService);
                                break;

                            case "2":
                                ViewGuestBookings(guest.GuestId, bookingService);
                                break;

                            case "3":
                                CancelBooking( guestId,  bookingService, roomService);
                                break;

                            case "0":
                                userRunning = false;
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Press any key.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }

            static bool AdminLogin()
            {
                Console.Clear();
                Console.WriteLine("Admin Login");

                Console.Write("Enter User name: ");
                string UserName = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                // Validate the credentials 
                if (UserName == "admin" && password == "1234")
                {
                    Console.WriteLine("Login successful!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid user name or password.");
                    Console.WriteLine("Press any key to return to main menu...");
                    Console.ReadKey();
                    return false;
                }
            }

            static void AddRoom(IRoomService roomService)
            {
                Console.Clear();
                Console.WriteLine("Add New Room");
                Console.Write("Enter Room ID: ");
                string roomId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(roomId))
                {
                    Console.WriteLine("Room ID is required.");
                    return;
                }
                if (roomService.GetRoomById(roomId) != null)
                {
                    Console.WriteLine("Room already exists.");
                    return;
                }
                Console.Write("Enter Room Type: ");
                string roomType = Console.ReadLine();

                Console.Write("Enter Room Price: ");
                decimal roomPrice;
                while (!decimal.TryParse(Console.ReadLine(), out roomPrice) || roomPrice <= 0)
                {
                    Console.Write("Invalid price. Please enter a valid Room Price: ");
                }
                var newRoom = new Room
                {
                    RoomId = roomId,
                    RoomType = roomType,
                    Price = roomPrice,
                    IsAvailable = true
                };
                roomService.AddRoom(newRoom);
                Console.WriteLine($"Room {newRoom.RoomId} added successfully!");
            }

            static void ViewRooms(IRoomService roomService)
            {
                Console.Clear();
                Console.WriteLine("Available Rooms:");

                var rooms = roomService.GetAllRooms();
                if (rooms.Count == 0)
                {
                    Console.WriteLine("No rooms available.");
                }
                else
                {
                    foreach (var room in rooms)
                    {
                        Console.WriteLine($"Room ID: {room.RoomId}, Type: {room.RoomType}, Price: {room.Price:C}, Available: {room.IsAvailable}");
                    }
                }
                Console.WriteLine("Press any key to return to the admin menu...");
                Console.ReadKey();
            }

            static void DeleteRoom(IRoomService roomService)
            {
                Console.Clear();
                Console.WriteLine("Delete Room");
                Console.Write("Enter Room ID to delete: ");
                string roomId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(roomId))
                {
                    Console.WriteLine("Room ID is required.");
                    return;
                }
                var room = roomService.GetRoomById(roomId);
                if (room == null)
                {
                    Console.WriteLine($"Room with ID {roomId} not found.");
                    return;
                }
                roomService.DeleteRoom(roomId);
                Console.WriteLine($"Room {roomId} deleted successfully!");
            }

            static void BookRoom(Guest guest, IRoomService roomService, IBookingService bookingService)
            {
                Console.Clear();
                Console.WriteLine("Book a Room");
                var availableRooms = roomService.GetAvailableRooms();
                if (availableRooms.Count == 0)
                {
                    Console.WriteLine("No rooms available for booking.");
                    return;
                }
                Console.WriteLine("Available Rooms:");
                foreach (var room in availableRooms)
                {
                    Console.WriteLine($"Room ID: {room.RoomId}, Type: {room.RoomType}, Price: {room.Price:C}");
                }
                Console.Write("Enter Room ID to book: ");
                string roomId = Console.ReadLine();
                var roomToBook = roomService.GetRoomById(roomId);
                if (roomToBook == null || !roomToBook.IsAvailable)
                {
                    Console.WriteLine($"Room with ID {roomId} is not available.");
                    return;
                }
                Console.Write("Enter Check-In Date (yyyy-mm-dd): ");
                DateTime checkInDate;
                while (!DateTime.TryParse(Console.ReadLine(), out checkInDate))
                {
                    Console.Write("Invalid date. Please enter a valid Check-In Date: ");
                }
                Console.Write("Enter Check-Out Date (yyyy-mm-dd): ");
                DateTime checkOutDate;
                while (!DateTime.TryParse(Console.ReadLine(), out checkOutDate) || checkOutDate <= checkInDate)
                {
                    Console.Write("Invalid date. Please enter a valid Check-Out Date: ");
                }
                var booking = new Booking
                {
                    BookingId = Guid.NewGuid().ToString(),
                    GuestId = guest.GuestId,
                    RoomId = roomToBook.RoomId,
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                    BookingDate = DateTime.Now
                };
                bookingService.AddBooking(booking);
                roomToBook.IsAvailable = false; // Mark the room as unavailable
                roomService.UpdateRoom(roomToBook);
                Console.WriteLine($"Room {roomToBook.RoomId} booked successfully from {checkInDate.ToShortDateString()} to {checkOutDate.ToShortDateString()}!");
            }

            static void ViewGuestBookings(string guestId, IBookingService bookingService)
            {
                Console.Clear();
                Console.WriteLine("Your Bookings:");
                var bookings = bookingService.GetBookingsByGuestId(guestId);
                if (bookings.Count == 0)
                {
                    Console.WriteLine("No bookings found.");
                }
                else
                {
                    foreach (var booking in bookings)
                    {
                        Console.WriteLine($"Booking ID: {booking.BookingId}, Room ID: {booking.RoomId}, Check-In: {booking.CheckInDate.ToShortDateString()}, Check-Out: {booking.CheckOutDate.ToShortDateString()}");
                    }
                }
                Console.WriteLine("Press any key to return to the user menu...");
                Console.ReadKey();
            }

            static void CancelBooking(string guestId, IBookingService bookingService, IRoomService roomService)
            {
                Console.Clear();
                Console.WriteLine("Cancel Booking");
                var bookings = bookingService.GetBookingsByGuestId(guestId);
                if (bookings.Count == 0)
                {
                    Console.WriteLine("No bookings found to cancel.");
                    return;
                }
                Console.WriteLine("Your Bookings:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingId}, Room ID: {booking.RoomId}, Check-In: {booking.CheckInDate.ToShortDateString()}, Check-Out: {booking.CheckOutDate.ToShortDateString()}");
                }
                Console.Write("Enter Booking ID to cancel: ");
                string bookingId = Console.ReadLine();
                var bookingToCancel = bookings.FirstOrDefault(b => b.BookingId == bookingId);
                if (bookingToCancel == null)
                {
                    Console.WriteLine($"Booking with ID {bookingId} not found.");
                    return;
                }
                bookingService.DeleteBooking(bookingId);
                var room = roomService.GetRoomById(bookingToCancel.RoomId);
                if (room != null)
                {
                    room.IsAvailable = true; // Mark the room as available
                    roomService.UpdateRoom(room);
                }
                Console.WriteLine($"Booking {bookingId} cancelled successfully!");
            }
        }
    }
}

