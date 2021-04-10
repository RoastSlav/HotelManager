using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue(true)]
        public bool Vacant { get; set; }

        [Required]
        public decimal PriceForAdult { get; set; }

        [Required]
        public decimal PriceForNonAdult { get; set; }

        public int? CurrentReservatonId { get; set; }
        public Reservation Reservation { get; set; }
    }

    public enum RoomType
    {
        [Display(Name = "Две единични легла")]
        TwoSingleBed = 1,
        [Display(Name = "Апартамент")]
        Apartament = 2,
        [Display(Name = "Двойно легло")]
        DoubleBed = 3,
        [Display(Name = "Мезонет")]
        Penthouse = 4,
    }
}
