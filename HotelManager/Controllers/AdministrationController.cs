using HotelManager.Areas.Identity.Data;
using HotelManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var erorr in result.Errors)
                {
                    ModelState.AddModelError("", erorr.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AuthUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    LastName = model.LastName,
                    EGN = model.EGN,
                    DateOfEmployment = model.DateOfEmployment,
                    DateOfTermination = model.DateOfTermination,
                    PhoneNumber = model.PhoneNumber,
                    LockoutEnabled = false
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return View("NotFound");
            }

            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EGN = user.EGN,
                Email = user.Email,
                DateOfEmployment = user.DateOfEmployment,
                DateOfTermination = user.DateOfTermination,
                IsActive = !user.LockoutEnabled,
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                user.Id = model.Id;
                user.UserName = model.Username;
                user.FirstName = model.FirstName;
                user.SecondName = model.SecondName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.EGN = model.EGN;
                user.Email = model.Email;
                user.DateOfEmployment = model.DateOfEmployment;
                user.DateOfTermination = model.DateOfTermination;
                user.LockoutEnabled = !model.IsActive;

                if (model.NewPassword != null)
                {
                    var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                    var addPasswordResult = await userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);
                    if (!addPasswordResult.Succeeded)
                    {
                        foreach (var error in addPasswordResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }

                        return View(model);
                    }
                }

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            ViewBag.userId = userId;

            if (user == null)
            {
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRoleViewModel> model, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }

        [HttpGet]
        public IActionResult userSearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var users = userManager.Users.Where(x => x.UserName.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()));
                return View("ListUsers", users);
            }

            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        public IActionResult roleSearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var roles = roleManager.Roles.Where(x => x.Name.Contains(search)).ToList();
                return View("ListRoles", roles);
            }

            return RedirectToAction("ListRoles");
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

    }
}
