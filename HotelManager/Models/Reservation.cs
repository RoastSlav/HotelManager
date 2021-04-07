using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Reservation
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public string ByUser { get; set; }

        [Required]
        public string Guests { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public DateTime LeavingDate { get; set; }

        public bool IncludedBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
