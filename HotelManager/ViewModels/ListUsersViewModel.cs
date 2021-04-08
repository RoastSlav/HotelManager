using HotelManager.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.ViewModels
{
    public class ListUsersViewModel
    {
        [Required]
        List<AuthUser> users = new List<AuthUser>();
    }
}
