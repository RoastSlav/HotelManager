﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class RoomController : Controller
    {
        [HttpGet]
        public IActionResult ListRoom() 
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditRoom()
        {
            return View();
        }

    }
}
