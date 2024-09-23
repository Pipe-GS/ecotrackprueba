using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoTrack.Models;
using EcoTrack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosClimaController : ControllerBase
    {
        private readonly DbContext _context;

        public DatosClimaController(DbContext context)
        {
            _context = context;
        }

        // GET: api/datosclima
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatosClima>>> GetDatosClima()
        {
            return await _context.DatosClima.ToListAsync(); // Devuelve la lista de datos clim�ticos
        }

        // GET: api/datosclima/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DatosClima>> GetDatosClima(int id)
        {
            var datosClima = await _context.DatosClima.FindAsync(id); // Busca los datos clim�ticos por ID
            if (datosClima == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra
            }

            return datosClima; // Devuelve los datos clim�ticos encontrados
        }

        // POST: api/datosclima
        [HttpPost]
        public async Task<ActionResult<DatosClima>> PostDatosClima([FromBody] DatosClima datosClima)
        {
            if (!ModelState.IsValid) // Verifica si el modelo es v�lido
            {
                return BadRequest(ModelState); // Devuelve un error 400 si no es v�lido
            }

            _context.DatosClima.Add(datosClima); // A�ade los datos clim�ticos al contexto
            await _context.SaveChangesAsync(); // Guarda los cambios

            return CreatedAtAction(nameof(GetDatosClima), new { id = datosClima.IdDatosClima }, datosClima); // Devuelve la acci�n creada
        }

        // PUT: api/datosclima/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatosClima(int id, [FromBody] DatosClima datosClima)
        {
            if (id != datosClima.IdDatosClima)
            {
                return BadRequest(); // Devuelve un error 400 si los IDs no coinciden
            }

            _context.Entry(datosClima).State = EntityState.Modified; // Marca los datos clim�ticos como modificados
            await _context.SaveChangesAsync(); // Guarda los cambios

            return NoContent(); // Devuelve un c�digo 204 sin contenido
        }

        // DELETE: api/datosclima/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatosClima(int id)
        {
            var datosClima = await _context.DatosClima.FindAsync(id); // Busca los datos clim�ticos por ID
            if (datosClima == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra
            }

            _context.DatosClima.Remove(datosClima); // Elimina los datos clim�ticos del contexto
            await _context.SaveChangesAsync(); // Guarda los cambios

            return NoContent(); // Devuelve un c�digo 204 sin contenido
        }
    }
}
