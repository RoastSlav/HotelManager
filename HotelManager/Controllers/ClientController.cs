using HotelManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public IActionResult ListClient()
        {
            using (var context = new HotelManagerDbContext())
            {
                var clients = context.Clients.AsParallel().ToList();
                return View(clients);
            }
        }

        [HttpGet]
        public IActionResult clientSearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                using (var context = new HotelManagerDbContext())
                {
                    var clients = context.Clients.AsParallel().Where(x => x.FirstName.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()) || x.PhoneNumber.Contains(search)).ToList();
                    return View("ListClient", clients);
                }
            }

            return RedirectToAction("ListClient");
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(Client model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Adult = model.Adult,
                    Email = model.Email
                };

                using (var context = new HotelManagerDbContext())
                {
                    await context.Clients.AddAsync(client);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction("ListClient");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditClient(int id)
        {
            using (var context = new HotelManagerDbContext())
            {
                var client = await context.Clients.FindAsync(id);

                if (client == null)
                {
                    return View("NotFound");
                }

                var model = new Client
                {
                    clientId = client.clientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    PhoneNumber = client.PhoneNumber,
                    Adult = client.Adult
                };

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditClient(Client model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new HotelManagerDbContext())
                {
                    var client = new Client
                    {
                        clientId = model.clientId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Adult = model.Adult
                    };
                    context.Clients.Update(client);
                    await context.SaveChangesAsync();
                    return RedirectToAction("ListClient");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            using (var context = new HotelManagerDbContext())
            {
                var client = await context.Clients.FindAsync(id);

                if (client == null)
                {
                    return View("NotFound");
                }

                context.Clients.Remove(client);
                await context.SaveChangesAsync();

                return RedirectToAction("ListClient");
            }
        }
    }
}
