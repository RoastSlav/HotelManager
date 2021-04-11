using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int clientId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public bool Adult { get; set; }

        public int? CurrentReservatonId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
