using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VuelosCRUD.Models;

namespace VuelosCRUD.Controllers
{
    public class VuelosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VuelosController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AltaVuelo(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                // Split the flight number into airline code and flight number
                string[] parts = vuelo.NumeroDeVuelo.Split(' ');
                if (parts.Length != 2)
                {
                    // Handle invalid flight number
                    return BadRequest("Invalid flight number");
                }
                string airlineCode = parts[0];

                {
                    var airline = _context.Aerolineas.FirstOrDefault(a => a.Iata == airlineCode);
                    if (airline != null)
                    {
                        vuelo.AerolineaId = airline.Id;
                    }
                    else
                    {
                        airline = _context.Aerolineas.FirstOrDefault(a => a.Icao == airlineCode);
                        if (airline != null)
                        {
                            vuelo.AerolineaId = airline.Id;
                        }
                        else return BadRequest("Invalid flight number");
                    }
                }

                var dbId = await _context.Vuelos.SingleOrDefaultAsync(c => c.Id == vuelo.Id);

                if (dbId != null && vuelo.Id == dbId.Id)
                {
                    ModelState.AddModelError("Id existente", "Ya existe este id, por favor pruebe otro.");
                    return BadRequest(ModelState);
                }



                await _context.Vuelos.AddAsync(vuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");


        }


        public IActionResult Baja()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Baja(int id)
        {

            var vuelo = await _context.Vuelos.SingleOrDefaultAsync(x => x.Id == id);

            if (vuelo == null)
                return NotFound();

            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
