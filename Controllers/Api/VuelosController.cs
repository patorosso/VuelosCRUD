using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VuelosCRUD.Dtos;
using VuelosCRUD.Models;

namespace VuelosCRUD.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VuelosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/vuelos/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VueloDto>>> GetVuelos()
        {
            IEnumerable<Vuelo> vueloList = await _context.Vuelos
                .Include(c => c.Aerolinea)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<VueloDto>>(vueloList));
        }


        // DELETE /api/vuelos/id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVuelo(int id)
        {
            if (id == 0)
                return BadRequest();

            var vuelo = await _context.Vuelos.SingleOrDefaultAsync(x => x.Id == id);

            if (vuelo == null)
                return NotFound();

            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
