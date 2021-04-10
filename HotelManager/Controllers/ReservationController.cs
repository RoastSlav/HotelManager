using HotelManager.Areas.Identity.Data;
using HotelManager.Models;
using HotelManager.ViewModels;
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
        public IActionResult ListRoomsForReservation(AddReservationViewModel model)
        {
            return View("ListRoomsForReservation", model);
        }

        [HttpPost]
        public IActionResult AddRoomToReservation(AddReservationViewModel model, Room room)
        {
            model.reservation.Room = room;
            return RedirectToAction("ListClientsForReservation", model);
        }

        [HttpGet]
        public IActionResult ListClientsForReservation(AddReservationViewModel model)
        {
            return View("ListRoomsForReservation", model);
        }

        [HttpPost]
        public IActionResult AddClientToReservation(AddReservationViewModel model, IEnumerable<Client> clients)
        {
            model.reservation.Guests = (ICollection<Client>)clients;
            return RedirectToAction("AddClientToReservation", model);
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> AddReservation(Reservation model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var reservation = new Reservation
        //        {
        //            ReservationDate = model.ReservationDate,
        //            LeavingDate = model.LeavingDate,
        //            AllInclusive = model.AllInclusive,
        //            IncludedBreakfast = model.IncludedBreakfast
        //        };

        //        using (var context = new HotelManagerDbContext())
        //        {
        //            await context.Reservations.AddAsync(reservation);
        //            await context.SaveChangesAsync();
        //            var reservationId = context.Reservations.Select(reservation);
        //        }

        //        return RedirectToAction("ListRoomsForReservation")
        //    };
        //}

        [HttpGet]
        public IActionResult EditReservation()
        {
            return View();
        }
    }
}
