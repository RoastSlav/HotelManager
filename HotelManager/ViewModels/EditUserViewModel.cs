using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.ViewModels
{
    public class EditUserViewModel
    {
        public class Input
        {
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string? NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }

            [Phone]
            [Required]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100)]
            public string Username { get; set; }

            [Required]
            [StringLength(100)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100)]
            public string SecondName { get; set; }

            [Required]
            [StringLength(100)]
            public string LastName { get; set; }

            [Required]
            public int EGN { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public DateTime DateOfEmployment { get; set; }

            public DateTime? DateOfTermination { get; set; }

            [Required]
            public bool IsActive { get; set; }
        }

        public Input input = new Input();
    }
}
