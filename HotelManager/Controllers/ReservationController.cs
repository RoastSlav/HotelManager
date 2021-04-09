using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public IActionResult ListReservation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditReservation()
        {
            return View();
        }
    }
}
