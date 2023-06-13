using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaJezyk.Models;

namespace ListaJezyk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : Controller
    {
        private readonly APIDbContext _context;

        public KategoriaController(APIDbContext context)
        {
            _context = context;
        }

        //Get api/Kategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategoria>>> GetKategoria()
        {
            return await _context.Kategorie.ToListAsync();
        }

        //get api/kategoria/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategoria>> GetKategoria(int id)
        {
            var kategoria = await _context.Kategorie.FindAsync(id); 
            if (kategoria == null)
            {
                return NotFound();
            }
            return kategoria;
        }

        //put api/kategoria/id

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategoria(int id, Kategoria kategoria)
        {
            if (id != kategoria.KategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(kategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    if (!KategoriaExists(id))
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
        //POST api/Kategoria

        public async Task<ActionResult<Kategoria>> PostKategoria(Kategoria kategoria)
        {
            _context.Kategorie.Add(kategoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategoria", new { id = kategoria.KategoriaId }, kategoria);

        }

        //Delete api/Kategoria/id

        [HttpDelete("{id}")]
        public async Task<ActionResult<Kategoria>> DeleteKategoria(int id)
        {
            var kategoria = await _context.Kategorie.FindAsync(id);
            if (kategoria == null)
            {
                return NotFound();
            }

            _context.Kategorie.Remove(kategoria);
            await _context.SaveChangesAsync();

            return kategoria;
        }

        private bool KategoriaExists(int id)
        {
            return _context.Kategorie.Any(e => e.KategoriaId == id);
        }

    }
}
