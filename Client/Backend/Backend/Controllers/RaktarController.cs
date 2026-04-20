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
        private int id;
        private IEnumerable<object> projektAlkatreszek;

        public RaktarController(PostgreDbContext context)
        {
            _context = context;
        }

        // POST: api/raktar
        //[Authorize(Roles = "raktarvezeto")]
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(Raktar raktar)
        {
            using var adatbazisTranzakcio = await _context.Database.BeginTransactionAsync();

            try
            {
                // ✔ ÚJ: rekesz ellenőrzés
                bool letezik = await _context.Raktar
                    .AnyAsync(r => r.RekeszId == raktar.RekeszId);

                if (letezik)
                    return BadRequest("A rekesz már foglalt");

                _context.Raktar.Add(raktar);
                await _context.SaveChangesAsync();

                int maradek = raktar.Darabszam;

                var hianyosLista = await _context.ProjektAlkatreszek
                    .Where(pa => pa.AlkatreszId == raktar.AlkatreszId && pa.HianyDb > 0)
                    .Join(_context.Projektek,
                        pa => pa.ProjektId,
                        p => p.Id,
                        (pa, p) => new { pa, p })
                    .Where(x => x.p.Statusz == "Wait")
                    .Select(x => x.pa)
                    .ToListAsync();

                foreach (var item in hianyosLista)
                {
                    if (maradek <= 0)
                        break;

                    if (item.HianyDb <= maradek)
                    {
                        maradek -= item.HianyDb;
                        item.HianyDb = 0;
                    }
                    else
                    {
                        item.HianyDb -= maradek;
                        maradek = 0;
                    }
                }

                await _context.SaveChangesAsync();
                await adatbazisTranzakcio.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await adatbazisTranzakcio.RollbackAsync();
                return BadRequest(ex.Message);
            }
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