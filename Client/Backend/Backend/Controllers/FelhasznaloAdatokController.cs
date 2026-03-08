using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FelhasznaloAdatok>>> GetFelhasznalok()
        {
            return await _context.Felhasznalok.ToListAsync();
        }

        // GET: api/FelhasznaloAdatoks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FelhasznaloAdatok>> GetFelhasznaloAdatok(int id)
        {
            var felhasznaloAdatok = await _context.Felhasznalok.FindAsync(id);

            if (felhasznaloAdatok == null)
            {
                return NotFound();
            }

            return felhasznaloAdatok;
        }

        // PUT: api/FelhasznaloAdatoks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<FelhasznaloAdatok>> PostFelhasznaloAdatok(FelhasznaloAdatok felhasznaloAdatok)
        {
            _context.Felhasznalok.Add(felhasznaloAdatok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFelhasznaloAdatok", new { id = felhasznaloAdatok.Id }, felhasznaloAdatok);
        }

        // DELETE: api/FelhasznaloAdatoks/5
        [HttpDelete("{id}")]
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
