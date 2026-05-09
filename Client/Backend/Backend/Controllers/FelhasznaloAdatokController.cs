using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FelhasznaloAdatokController : ControllerBase
    {
        private readonly PostgreDbContext _context;

        public FelhasznaloAdatokController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: api/FelhasznaloAdatoks
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FelhasznaloGet>>> GetFelhasznalok()
        {
            var felhasznalok = await _context.Felhasznalok
                .Select(f => new FelhasznaloGet
                {
                    Id = f.Id,
                    Nev = f.Nev,
                    Szerepkor = f.Szerepkor,
                    Email = f.Email
                }).ToListAsync();

            return felhasznalok;
        }

        // GET: api/FelhasznaloAdatoks/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<FelhasznaloGet>> GetFelhasznaloAdatok(int id)
        {
            var felhasznalo = await _context.Felhasznalok
                .Where(f => f.Id == id)
                .Select(f => new FelhasznaloGet
                {
                    Id = f.Id,
                    Nev = f.Nev,
                    Szerepkor = f.Szerepkor,
                    Email = f.Email
                }).FirstOrDefaultAsync();

            if (felhasznalo == null)
            {
                return NotFound();
            }

            return felhasznalo;
        }

        // PUT: api/FelhasznaloAdatoks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutFelhasznaloAdatok(int id, FelhasznaloAdatok felhasznaloAdatok)
        {
            if (id != felhasznaloAdatok.Id)
            {
                return BadRequest();
            }

            _context.Entry(felhasznaloAdatok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FelhasznaloAdatokExists(id))
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

        // POST: api/FelhasznaloAdatoks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<FelhasznaloAdatok>> PostFelhasznaloAdatok(FelhasznaloAdatok felhasznaloAdatok)
        {
            _context.Felhasznalok.Add(felhasznaloAdatok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFelhasznaloAdatok", new { id = felhasznaloAdatok.Id }, felhasznaloAdatok);
        }

        // DELETE: api/FelhasznaloAdatoks/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteFelhasznaloAdatok(int id)
        {
            var felhasznaloAdatok = await _context.Felhasznalok.FindAsync(id);
            if (felhasznaloAdatok == null)
            {
                return NotFound();
            }

            _context.Felhasznalok.Remove(felhasznaloAdatok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FelhasznaloAdatokExists(int id)
        {
            return _context.Felhasznalok.Any(e => e.Id == id);
        }
    }
}
