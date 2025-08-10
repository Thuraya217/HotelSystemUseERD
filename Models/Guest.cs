using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Models
{
    public class Guest
    {

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string GuestName { get; set; }
        public string GuestId { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation properties
        public ICollection <Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
