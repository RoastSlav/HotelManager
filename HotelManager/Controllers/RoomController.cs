using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult AddRoom()
        {
            return View();
        }

        public IActionResult EditRoom()
        {
            return View();
        }
    }
}
