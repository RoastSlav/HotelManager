using HotelManager.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EditUser(EditUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = User.Identity.Name;
                return;
            }
            return;
        }
    }
}
