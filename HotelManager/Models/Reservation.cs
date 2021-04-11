using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models
{
    public class Reservation
    {
        [Required]
        [Key]
        public int reservationId { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        public string creatingUserId { get; set; }

        [Required]
        public ICollection<Client> Guests { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public DateTime LeavingDate { get; set; }

        [Required]
        public bool IncludedBreakfast { get; set; }

        [Required]
        public bool AllInclusive { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
