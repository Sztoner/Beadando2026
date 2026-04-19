using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly PostgreDbContext _context;

        public ProjektController(PostgreDbContext context)
        {
            _context = context;
        }

        // POST: api/projekt
        //[Authorize(Roles = "szakember")]
        [HttpPost]
        public async Task<IActionResult> Create(Projekt projekt)
        {
            _context.Projektek.Add(projekt);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // GET: api/projekt
        //[Authorize(Roles = "szakember,raktaros")]
        [HttpGet]
        public async Task<List<Projekt>> GetAll()
        {
            return await _context.Projektek.ToListAsync();
        }

        // GET: api/projekt/{id}
        //[Authorize(Roles = "szakember,raktaros")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var projekt = await _context.Projektek.FindAsync(id);

            return Ok(projekt);
        }

        // PUT: api/projekt
        //[Authorize(Roles = "szakember")]
        [HttpPut]
        public async Task<IActionResult> Update(Projekt projekt)
        {
            var meglevoProjekt = await _context.Projektek.FindAsync(projekt.Id);

            if (meglevoProjekt == null)
                return NotFound();

            _context.Entry(meglevoProjekt).CurrentValues.SetValues(projekt);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/projekt/{id}/alkatresz
        //[Authorize(Roles = "szakember")]
        [HttpPost("{id}/alkatresz")]
        public async Task<IActionResult> AddAlkatresz(int id, List<ProjektAlkatresz> alkatreszLista)
        {
            foreach (var alkatresz in alkatreszLista)
            {
                bool letezik = _context.ProjektAlkatreszek
                    .Any(x => x.ProjektId == id && x.AlkatreszId == alkatresz.AlkatreszId);

                if (letezik)
                    return BadRequest("Már létezik ilyen alkatrész a projektben");

                alkatresz.ProjektId = id;
                _context.ProjektAlkatreszek.Add(alkatresz);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        // GET: api/projekt/{id}/alkatresz
        //[Authorize(Roles = "szakember,raktaros")]
        [HttpGet("{id}/alkatresz")]
        public async Task<IActionResult> GetAlkatreszek(int id)
        {
            var projektAlkatreszLista = await _context.ProjektAlkatreszek
                .Where(pa => pa.ProjektId == id)
                .Join(_context.Projektek,
                    pa => pa.ProjektId,
                    p => p.Id,
                    (pa, p) => new { pa, p })
                .Join(_context.Alkatreszek,
                    x => x.pa.AlkatreszId,
                    a => a.Id,
                    (x, a) => new ProjektAlkatreszGet
                    {
                        ProjektId = x.p.Id,
                        ProjektNev = x.p.Nev,
                        AlkatreszId = a.Id,
                        AlkatreszNev = a.Nev,
                        Darabszam = x.pa.Darabszam,
                        HianyDb = x.pa.HianyDb
                    })
                .ToListAsync();

            return Ok(projektAlkatreszLista);
        }

        // POST: api/projekt/naplo
        //[Authorize(Roles = "szakember")]
        [HttpPost("naplo")]
        public async Task<IActionResult> Naplo(Naplo naplo)
        {
            _context.Naplok.Add(naplo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("scheduled")]
        public async Task<ActionResult<List<Projekt>>> GetScheduled()
        {
            return await _context.Projektek
                .Where(p => p.Statusz == "Scheduled")
                .ToListAsync();
        }

        [HttpGet("{id}/alkatreszar")]
        public async Task<ActionResult<int>> GetALkatreszAr(int id)
        {
            var osszeg = await _context.ProjektAlkatreszek
                .Where(pa => pa.ProjektId == id)
        .Join(_context.Alkatreszek,
            pa => pa.AlkatreszId,
            a => a.Id,
            (pa, a) => new { pa, a })
        .SumAsync(x => x.pa.Darabszam * x.a.Ar);
            return Ok(osszeg);
        }

        [HttpGet("{id}/kivitelez")]
        public async Task<ActionResult<List<Raktar>>> Kivitelez(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var felhasznaltRaktarKeszlet = new List<Raktar>();

                var projektAlkatreszek = await _context.ProjektAlkatreszek
                    .Where(pa => pa.ProjektId == id)
                    .ToListAsync();

                foreach (var pa in projektAlkatreszek)
                {
                    int szuksegesDb = pa.Darabszam;

                    var raktarLista = await _context.Raktar
                        .Where(r => r.AlkatreszId == pa.AlkatreszId)
                        .OrderBy(r => r.Darabszam)
                        .ToListAsync();

                    int osszes = raktarLista.Sum(r => r.Darabszam);

                    // ✔ hibakezelés
                    if (osszes < szuksegesDb)
                    {
                        await transaction.RollbackAsync();
                        return BadRequest($"Nincs elég készlet az alkatrészhez: {pa.AlkatreszId}");
                    }

                    foreach (var r in raktarLista)
                    {
                        if (szuksegesDb <= 0)
                            break;

                        if (r.Darabszam <= szuksegesDb)
                        {
                            // teljes kivét
                            szuksegesDb -= r.Darabszam;

                            felhasznaltRaktarKeszlet.Add(new Raktar
                            {
                                RekeszId = r.RekeszId,
                                AlkatreszId = r.AlkatreszId,
                                AlkatreszNev = r.AlkatreszNev,
                                Darabszam = r.Darabszam
                            });

                            _context.Raktar.Remove(r);
                        }
                        else
                        {
                            // részleges kivét
                            felhasznaltRaktarKeszlet.Add(new Raktar
                            {
                                RekeszId = r.RekeszId,
                                AlkatreszId = r.AlkatreszId,
                                Darabszam = szuksegesDb
                            });

                            r.Darabszam -= szuksegesDb;
                            szuksegesDb = 0;
                        }
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(felhasznaltRaktarKeszlet);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }
    }
}