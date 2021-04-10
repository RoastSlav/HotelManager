using HotelManager.Models;
using Microsoft.AspNetCore.Mvc;
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
            using (var context = new HotelManagerDbContext())
            {
                var rooms = context.Rooms.AsParallel().ToList();
                return View(rooms);
            }
        }

        [HttpGet]
        public IActionResult showVacant()
        {
                using (var context = new HotelManagerDbContext())
                {
                    var rooms = context.Rooms.AsParallel().Where(x => x.Vacant == true).ToList();
                    return View("ListRoom", rooms);
                }
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room model)
        {
            if (ModelState.IsValid)
            {
                var room = new Room
                {
                    RoomNumber = model.RoomNumber,
                    Capacity = model.Capacity,
                    RoomType = model.RoomType,
                    Vacant = true,
                    PriceForAdult = model.PriceForAdult,
                    PriceForNonAdult = model.PriceForNonAdult
                };

                using (var context = new HotelManagerDbContext())
                {
                    await context.Rooms.AddAsync(room);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction("ListRoom");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRoom(int id)
        {
            using (var context = new HotelManagerDbContext())
            {
                var room = await context.Rooms.FindAsync(id);

                if (room == null)
                {
                    return View("NotFound");
                }

                var model = new Room
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    Capacity = room.Capacity,
                    RoomType = room.RoomType,
                    Vacant = room.Vacant,
                    PriceForAdult = room.PriceForAdult,
                    PriceForNonAdult = room.PriceForNonAdult
                };

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditRoom(Room model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new HotelManagerDbContext())
                {
                    var room = new Room
                    {
                        RoomId = model.RoomId,
                        RoomNumber = model.RoomNumber,
                        Capacity = model.Capacity,
                        RoomType = model.RoomType,
                        Vacant = true,
                        PriceForAdult = model.PriceForAdult,
                        PriceForNonAdult = model.PriceForNonAdult
                    };
                    context.Rooms.Update(room);
                    await context.SaveChangesAsync();
                    return RedirectToAction("ListRoom");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            using (var context = new HotelManagerDbContext())
            {
                var room = await context.Rooms.FindAsync(id);

                if (room == null)
                {
                    return View("NotFound");
                }

                context.Rooms.Remove(room);
                await context.SaveChangesAsync();

                return RedirectToAction("ListRoom");
            }
        }
    }
}
