using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Models
{
    public class Review
    {
        [Key]
        public string ReviewId { get; set; }
        public string RoomId { get; set; } // Foreign key to Room
        public string GuestId { get; set; } // Foreign key to Guest
        public string Comment { get; set; }

        // Navigation properties
        public Room room { get; set; }
        public Guest guest { get; set; }

    }
}
