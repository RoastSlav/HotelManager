using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Room
    {
        [Required, Key]
        public int RoomNumber { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string RoomType { get; set; }

        public bool Vacancy { get; set; }

        public decimal PriceForAdult { get; set; }

        public decimal PriceForNonAdult { get; set; }
    }
}
