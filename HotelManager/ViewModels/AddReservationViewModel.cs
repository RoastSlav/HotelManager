using HotelManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HotelManager.ViewModels
{
    [BindProperties]
    public class AddReservationViewModel
    {
        public AddReservationViewModel()
        {
            reservation = new Reservation();

            using (var context = new HotelManagerDbContext())
            {
                rooms = context.Rooms.AsParallel().ToList();
                clients = context.Clients.AsParallel().ToList();
            }
        }
        [Required]
        public Reservation reservation { get; set; }
        [Required]
        public List<Client> clients { get; set; }
        [Required]
        public List<Room> rooms { get; set; }
    }
}
