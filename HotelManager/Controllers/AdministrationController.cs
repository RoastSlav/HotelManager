using HotelManager.Areas.Identity.Data;
using HotelManager.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AuthUser> userManager;

        public AdministrationController(
            RoleManager<IdentityRole> roleManager,
            UserManager<AuthUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            //var user = await userManager.FindByIdAsync(id);

            //if(user == null)
            //{
            //    return View("NotFound");
            //}

            //var userRoles = await userManager.GetRolesAsync(user);

            //var model = new EditUserViewModel
            //{
            //    Id = user.Id,
            //    Username = user.UserName,
            //    FirstName = user.FirstName,
            //    SecondName = user.SecondName,
            //    LastName = user.LastName,
            //    PhoneNumber = user.PhoneNumber,
            //    EGN = user.EGN,
            //    Email = user.Email,
            //    DateOfEmployment = user.DateOfEmployment,
            //    DateOfTermination = user.DateOfTermination,
            //    IsActive = !user.LockoutEnabled,
            //    Roles = userRoles
            //};
            return View();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();

        }
    }
}
