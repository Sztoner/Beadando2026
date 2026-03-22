using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaktarController : ControllerBase
    {
        private readonly PostgreDbContext _context;

        public RaktarController(PostgreDbContext context)
        {
            _context = context;
        }

        // POST: api/raktar
        //[Authorize(Roles = "raktarvezeto")]
        [HttpPost]
        public async Task<IActionResult> Create(Raktar raktar)
        {
            _context.Set<Raktar>().Add(raktar);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // GET: api/raktar
        //[Authorize(Roles = "raktarvezeto,raktaros")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var raktarLista = await _context.Raktar
                .Join(_context.Alkatreszek,
                    r => r.AlkatreszId,
                    a => a.Id,
                    (r, a) => new
                    {
                        r.RekeszId,
                        r.AlkatreszId,
                        AlkatreszNev = a.Nev,
                        r.Darabszam
                    })
                .ToListAsync();

            return Ok(raktarLista);
        }

        // PUT: api/raktar
        //[Authorize(Roles = "raktarvezeto")]
        [HttpPut]
        public async Task<IActionResult> Update(Raktar raktar)
        {
            var meglevoRekesz = await _context.Raktar
                .FirstOrDefaultAsync(r => r.RekeszId == raktar.RekeszId);

            if (meglevoRekesz == null)
                return NotFound();

            _context.Entry(meglevoRekesz).CurrentValues.SetValues(raktar);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/raktar/{id}
        //[Authorize(Roles = "raktarvezeto")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var meglevoRekesz = await _context.Set<Raktar>()
                .FirstOrDefaultAsync(r => r.RekeszId == id);

            if (meglevoRekesz == null)
                return NotFound();

            _context.Remove(meglevoRekesz);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}