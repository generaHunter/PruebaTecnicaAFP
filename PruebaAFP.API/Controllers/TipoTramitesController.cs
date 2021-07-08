using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaAFP.API.Data;
using PruebaAFP.API.Models;

namespace PruebaAFP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTramitesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoTramitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoTramites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTramite>>> GetTipoTramites()
        {
            return await _context.TipoTramites.ToListAsync();
        }

        // GET: api/TipoTramites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTramite>> GetTipoTramite(int id)
        {
            var tipoTramite = await _context.TipoTramites.FindAsync(id);

            if (tipoTramite == null)
            {
                return NotFound();
            }

            return tipoTramite;
        }

        // PUT: api/TipoTramites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTramite(int id, TipoTramite tipoTramite)
        {
            if (id != tipoTramite.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoTramite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTramiteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoTramites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTramite>> PostTipoTramite(TipoTramite tipoTramite)
        {
            _context.TipoTramites.Add(tipoTramite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTramite", new { id = tipoTramite.Id }, tipoTramite);
        }

        // DELETE: api/TipoTramites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTramite(int id)
        {
            var tipoTramite = await _context.TipoTramites.FindAsync(id);
            if (tipoTramite == null)
            {
                return NotFound();
            }

            _context.TipoTramites.Remove(tipoTramite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTramiteExists(int id)
        {
            return _context.TipoTramites.Any(e => e.Id == id);
        }
    }
}
