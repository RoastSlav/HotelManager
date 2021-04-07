using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, Key]
        public int PhoneNumber { get; set; }

        [Required, Key]
        public string Email { get; set; }

        public bool Adult { get; set; } = true;
    }
}
