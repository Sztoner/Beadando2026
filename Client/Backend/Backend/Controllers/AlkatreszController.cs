using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlkatreszController : ControllerBase
    {
        private readonly PostgreDbContext _context;

        public AlkatreszController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: api/Alkatreszs
        [Authorize(Roles = "raktarvezeto")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alkatresz>>> GetAlkatreszek()
        {
            return await _context.Alkatreszek.ToListAsync();
        }

        // GET: api/Alkatreszs/5
        [Authorize(Roles = "raktarvezeto")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Alkatresz>> GetAlkatresz(int id)
        {
            var alkatresz = await _context.Alkatreszek.FindAsync(id);

            if (alkatresz == null)
            {
                return NotFound();
            }

            return alkatresz;
        }

        // PUT: api/Alkatreszs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "raktarvezeto")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlkatresz(int id, Alkatresz alkatresz)
        {
            if (id != alkatresz.Id)
            {
                return BadRequest();
            }

            _context.Entry(alkatresz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlkatreszExists(id))
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

        // POST: api/Alkatreszs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "raktarvezeto")]
        [HttpPost]
        public async Task<ActionResult<Alkatresz>> PostAlkatresz(Alkatresz alkatresz)
        {
            _context.Alkatreszek.Add(alkatresz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlkatresz", new { id = alkatresz.Id }, alkatresz);
        }

        // DELETE: api/Alkatreszs/5
        [Authorize(Roles = "raktarvezeto")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlkatresz(int id)
        {
            var alkatresz = await _context.Alkatreszek.FindAsync(id);
            if (alkatresz == null)
            {
                return NotFound();
            }

            _context.Alkatreszek.Remove(alkatresz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlkatreszExists(int id)
        {
            return _context.Alkatreszek.Any(e => e.Id == id);
        }
    }
}
