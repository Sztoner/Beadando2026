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
        private int id;

        public AlkatreszController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: api/Alkatreszs
        //[Authorize(Roles = "raktarvezeto,raktaros")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alkatresz>>> GetAlkatreszek()
        {
            return await _context.Alkatreszek.ToListAsync();
        }

        // GET: api/Alkatreszs/5
        //[Authorize(Roles = "raktarvezeto")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Alkatresz>> GetAlkatresz(int id)
        {
            var alkatresz = await _context.Alkatreszek.FindAsync(id);

            if (alkatresz == null)
            {
                return NotFound();
            }

            //ezt én tettem hozzá, nem tudom hogy jó-e
            //_context.Entry(alkatresz).CurrentValues.SetValues(alkatresz);
            //await _context.SaveChangesAsync();
            //return alkatresz

            return Ok(alkatresz);
        }

        // PUT: api/Alkatreszs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize(Roles = "raktarvezeto")]
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
        //[Authorize(Roles = "raktarvezeto")]
        [HttpPost]
        public async Task<ActionResult<Alkatresz>> PostAlkatresz(Alkatresz alkatresz)
        {
            bool letezik = await _context.Alkatreszek.AnyAsync(a => a.Nev.ToLower() == alkatresz.Nev.ToLower());

            if (letezik)
            {
                return BadRequest("Már létezik ilyen nevű alkatrész.");
            }

            _context.Alkatreszek.Add(alkatresz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlkatresz", new { id = alkatresz.Id }, alkatresz);
        }

        // DELETE: api/Alkatreszs/5
        //[Authorize(Roles = "raktarvezeto")]
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


        //[Authorize(Roles = "raktarvezeto,raktaros")]
        [HttpGet("{id}/elerhetoseg")]
        public async Task<IActionResult> GetElerhetoseg(int id)
        {
            var raktarDb = await _context.Raktar
                .Where(x => x.AlkatreszId == id)
                .SumAsync(x => x.Darabszam);

            var foglaltDb = await _context.ProjektAlkatreszek
                .Where(x => x.AlkatreszId == id /*&& x.HianyDb == 0*/)
                .Join(_context.Projektek,
                    pa => pa.ProjektId,
                    p => p.Id,
                    (pa, p) => new { pa, p })
                .Where(x => x.p.Statusz == "Draft" || x.p.Statusz == "Wait" || x.p.Statusz == "Scheduled")
                .SumAsync(x => x.pa.Darabszam);

            return Ok(new
            {
                AlkatreszId = id,
                RaktarDb = raktarDb,
                FoglaltDb = foglaltDb
            });
        }

        [HttpGet("hianyzok")]
        public async Task<ActionResult<List<Alkatresz>>> GetHianyzok()
        {
            var result = await _context.ProjektAlkatreszek
       .Where(pa => pa.HianyDb > 0)
       .GroupBy(pa => pa.AlkatreszId)
       .Select(g => new
       {
           AlkatreszId = g.Key,
           MaxHiany = g.Max(x => x.HianyDb)
       })
        .Join(_context.Alkatreszek,
            g => g.AlkatreszId,
            a => a.Id,
            (g, a) => new Alkatresz
            {
                Id = a.Id,
                Nev = a.Nev,
                Ar = a.Ar,
                MaxDb = g.MaxHiany
            })
        .ToListAsync();
            return Ok(result);
        }
    }
}
