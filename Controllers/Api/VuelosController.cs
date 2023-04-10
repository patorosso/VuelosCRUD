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

        // GET /api/vuelos/id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VueloDto>> GetVuelo(int id)
        {
            if (id == 0)
                return BadRequest();

            var vuelo = await _context.Vuelos
                .Include(c => c.Aerolinea)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (vuelo == null)
                return NotFound();

            return Ok(_mapper.Map<VueloDto>(vuelo));
        }

        // POST /api/vuelos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VueloDto>> PostVuelo([FromBody] VueloDto vueloDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (vueloDto == null)
                return BadRequest(vueloDto);

            if (vueloDto.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            // Split the flight number into airline code and flight number
            string[] parts = vueloDto.NumeroDeVuelo.Split(' ');
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
                    vueloDto.AerolineaId = airline.Id;
                }
                else
                {
                    airline = _context.Aerolineas.FirstOrDefault(a => a.Icao == airlineCode);
                    if (airline != null)
                    {
                        vueloDto.AerolineaId = airline.Id;
                    }
                    else return BadRequest("Invalid flight number");
                }
            }

            //check id duplicado
            var dbId = await _context.Vuelos.SingleOrDefaultAsync(c => c.Id == vueloDto.Id);
            if (dbId != null && vueloDto.Id == dbId.Id)
            {
                ModelState.AddModelError("Id existente", "Ya existe este id, por favor pruebe otro.");
                return BadRequest(ModelState);
            }
            //check numeroDeVuelo duplicado
            var vueloNumeroDuplicadoInDb = await _context.Vuelos.SingleOrDefaultAsync(c => c.NumeroDeVuelo == vueloDto.NumeroDeVuelo); // busco en mi db el num de vuelo
            if (vueloNumeroDuplicadoInDb != null && vueloNumeroDuplicadoInDb.Id != vueloDto.Id) // si es un match, el unico valor que admito es el mismo, porque quizas quiero el mismo numVuelo, pero cambio detalles.
            {
                ModelState.AddModelError("Numero de vuelo existente", "Ya existe este numero de vuelo, por favor pruebe otro.");
                return BadRequest(ModelState);
            }

            Vuelo postedVuelo = _mapper.Map<Vuelo>(vueloDto); // creo un modelo de Vuelo usando el vueloDto del param de la func

            await _context.Vuelos.AddAsync(postedVuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVuelo), new { id = vueloDto.Id }, vueloDto);
        }


        // DELETE /api/vuelos/id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVuelo(int? id)
        {

            if (id == 0 || id == null)
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
