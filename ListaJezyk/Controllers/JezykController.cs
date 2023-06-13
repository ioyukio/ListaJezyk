using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaJezyk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaJezyk.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JezykController : ControllerBase
    {
        private readonly APIDbContext _context;

        //controller z injection z db;
        public JezykController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Jezyk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jezyk>>> GetJezyk()
        {
            return await _context.Jezyki.ToListAsync();
        }

        // GET: api/Jezyk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jezyk>> GetJezyk(int id)
        {
            var jezyk = await _context.Jezyki.FindAsync(id);

            if (jezyk == null)
            {
                return NotFound();
            }

            return jezyk;
        }

        // PUT: api/Jezyk/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJezyk(int id, Jezyk jezyk)
        {
            if (id != jezyk.JezykId)
            {
                return BadRequest();
            }

            _context.Entry(jezyk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JezykExists(id))
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

        // POST: api/Jezyk
        [HttpPost]
        public async Task<ActionResult<Jezyk>> PostJezyk(Jezyk jezyk)
        {
            _context.Jezyki.Add(jezyk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJezyk", new { id = jezyk.JezykId }, jezyk);
        }

        // DELETE: api/Jezyk/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jezyk>> DeleteJezyk(int id)
        {
            var jezyk = await _context.Jezyki.FindAsync(id);
            if (jezyk == null)
            {
                return NotFound();
            }

            _context.Jezyki.Remove(jezyk);
            await _context.SaveChangesAsync();

            return jezyk;
        }

        private bool JezykExists(int id)
        {
            return _context.Jezyki.Any(e => e.JezykId == id);
        }
    }
}