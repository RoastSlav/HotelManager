using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int RoomId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public bool Vacant { get; set; }

        [Required]
        public decimal PriceForAdult { get; set; }

        [Required]
        public decimal PriceForNonAdult { get; set; }

        public int CurrentReservatonId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
