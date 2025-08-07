using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using HotelSystemUseERD.Models;

namespace HotelSystemUseERD
{
    public static class FileContext
    {
        private static string FilePath = "HotelSystem.json";
        private static string ReviewFilePath = "reviews.json";
        private static string RoomFilePath = "rooms.json";
        private static string BookingFilePath = "bookings.json";
        private static string GuestFilePath = "guests.json";


        public static List<Room> LoadRoom()
        {
            if (!File.Exists(FilePath))
                return new List<Room>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }

        public static void SaveRooms(List<Room> rooms)
        {
            var json = JsonSerializer.Serialize(rooms);
            File.WriteAllText(FilePath, json);
        }


        public static List<Review> LoadReview()
        {
            if (!File.Exists(FilePath))
                return new List<Review>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Review>>(json) ?? new List<Review>();
        }

        public static void SaveReview(List<Review> reviews)
        {
            var json = JsonSerializer.Serialize(reviews);
            File.WriteAllText(FilePath, json);
        }

        public static List<Booking> LoadBookings()
        {
            if (!File.Exists(FilePath))
                return new List<Booking>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
        }

        public static void SaveBooking(List<Booking> bookings)
        {
            var json = JsonSerializer.Serialize(bookings);
            File.WriteAllText(FilePath, json);
        }

        public static List<Guest> LoadGuests()
        {
            if (!File.Exists(FilePath))
                return new List<Guest>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Guest>>(json) ?? new List<Guest>();
        }

        public static void SaveGuests(List<Guest> guests)
        {
            var json = JsonSerializer.Serialize(guests);
            File.WriteAllText(FilePath, json);
        }
    }
}
