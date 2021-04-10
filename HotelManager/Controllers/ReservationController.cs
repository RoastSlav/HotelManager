using HotelManager.Areas.Identity.Data;
using HotelManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<AuthUser> userManager;

        public ReservationController(
            UserManager<AuthUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListReservation()
        {
            using (var context = new HotelManagerDbContext())
            {
                var reservations = context.Reservations.AsParallel().ToList();
                return View(reservations);
            }
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                var reservation = new Reservation
                {

                };

                using (var context = new HotelManagerDbContext())
                {
                    await context.Reservations.AddAsync(reservation);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction("ListReservation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditReservation()
        {
            return View();
        }
    }
}
