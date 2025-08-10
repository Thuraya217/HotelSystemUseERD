using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Models
{
    public class Booking
    {
        [Key]
        public string BookingId { get; set; }
        public string GuestId { get; set; } // Foreign key to Guest
        public string RoomId { get; set; } // Foreign key to Room
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        // Navigation properties
        public Guest Guest { get; set; }
        public Room Room { get; set; }
    }
}
