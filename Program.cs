

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
                            AdminMenu(guestService, roomService, bookingService, reviewService);
                            break;

                        case "2":
                            UserMenu(guestService, roomService, bookingService, reviewService);
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

                static void AdminMenu(GuestService guestService, RoomService roomService, BookingService bookingService, ReviewService reviewService)
                {

                    if (!AdminLogin())
                    {
                        Console.WriteLine("Invalid admin name or password. Returning to main menu...");
                        return;
                    }

                    bool adminRunning = true;
                    while (adminRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Admin Menu ===");
                        Console.WriteLine("1. Add Room");
                        Console.WriteLine("2. View All Rooms");
                        Console.WriteLine("3. View All Bookings");
                        Console.WriteLine("4. Delete Room");
                        Console.WriteLine("5. Delete Booking");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Choose option: ");

                        string adminChoice = Console.ReadLine();
                        switch (adminChoice)
                        {
                            case "1":
                               //AddRoom(roomService);
                                break;

                            case "2":
                              //ViewRooms(roomService);
                                break;

                            case "3":
                             // ViewBookings(bookingService);
                                break;

                            case "4":
                             // DeleteRoom(roomService);
                                break;

                            case "5":
                             // DeleteBooking(bookingService);
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

                static void UserMenu(GuestService guestService, RoomService roomService, BookingService bookingService, ReviewService reviewService)
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
                            // BookRoom(guest, roomService, bookingService);
                                break;

                            case "2":
                            // ViewGuestBookings(guest.GuestId, bookingService);
                                break;

                            case "3":
                            // CancelBooking(guest.GuestId, bookingService);
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
                    Console.WriteLine("Invalid credentials.");
                    Console.WriteLine("Press any key to return to main menu...");
                    Console.ReadKey();
                    return false;
                }
            }

        }
    }
}

