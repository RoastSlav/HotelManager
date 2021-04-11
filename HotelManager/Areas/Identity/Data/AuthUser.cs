using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class AuthUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string SecondName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int EGN { get; set; }

        [PersonalData]
        [Column(TypeName = "date")]
        public DateTime DateOfEmployment { get; set; }

        [PersonalData]
        [Column(TypeName = "date")]
        public DateTime? DateOfTermination { get; set; }
    }
}
