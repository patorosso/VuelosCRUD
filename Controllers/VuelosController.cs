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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alta(Vuelo vuelo)
        {
            var dbId = await _context.Vuelos.SingleOrDefaultAsync(c => c.NumeroDeVuelo == vuelo.NumeroDeVuelo);

            if (dbId != null)
                ModelState.AddModelError("NumeroDeVuelo", "Ya existe este vuelo, por favor pruebe otro.");


            if (ModelState.IsValid)
            {
                string[] parts = vuelo.NumeroDeVuelo.Split(' ');

                var airline = _context.Aerolineas.FirstOrDefault(a => a.Iata == parts[0]);
                if (airline != null)
                {
                    vuelo.AerolineaId = airline.Id;
                }
                else
                {
                    airline = _context.Aerolineas.FirstOrDefault(a => a.Icao == parts[0]);
                    if (airline != null)
                    {
                        vuelo.AerolineaId = airline.Id;
                    }
                    else vuelo.AerolineaId = 1; // Unknown airline on my db
                }





                await _context.Vuelos.AddAsync(vuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();


        }


        public IActionResult Baja()
        {
            return View();
        }
        [HttpPost] //En realidad delete
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
