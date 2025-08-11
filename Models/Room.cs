using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelSystemUseERD.Models
{
    public class Room
    {
        [Key]
        public string RoomId { get; set; }

        [Required]
        [RegularExpression("^(Single|Double)$")]
        public string RoomType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        // Navigation properties
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
