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

        //[Authorize(Roles = "raktaros")]
        [HttpGet("{id}/kivitelez")]
        public async Task<ActionResult<List<Raktar>>> Kivitelez(int id)
        {
            using var adatbazisTranzakcio = await _context.Database.BeginTransactionAsync();

            try
            {
                var felhasznaltRaktarKeszlet = new List<Raktar>();

                var projektAlkatreszek = await _context.ProjektAlkatreszek
                    .Where(pa => pa.ProjektId == id)
                    .ToListAsync();

                foreach (var pa in projektAlkatreszek)
                {
                    int hatralevoDb = pa.Darabszam;

                    var raktarLista = await _context.Raktar
                        .Where(r => r.AlkatreszId == pa.AlkatreszId)
                        .Join(_context.Alkatreszek,
                            r => r.AlkatreszId,
                            a => a.Id,
                            (r, a) => new Raktar
                            {
                                RekeszId = r.RekeszId,
                                AlkatreszId = r.AlkatreszId,
                                AlkatreszNev = a.Nev,
                                Darabszam = r.Darabszam
                            })
                        .OrderBy(r => r.Darabszam)
                        .ToListAsync();

                    int osszesDb = raktarLista.Sum(r => r.Darabszam);

                    if (osszesDb < hatralevoDb)
                    {
                        await adatbazisTranzakcio.RollbackAsync();
                        return BadRequest($"Nincs elég készlet: AlkatreszId = {pa.AlkatreszId}");
                    }

                    foreach (var r in raktarLista)
                    {
                        if (hatralevoDb <= 0)
                            break;

                        var eredetiRaktar = await _context.Raktar
                            .FirstOrDefaultAsync(x => x.RekeszId == r.RekeszId);

                        if (eredetiRaktar == null)
                            continue;

                        if (eredetiRaktar.Darabszam <= hatralevoDb)
                        {
                            hatralevoDb -= eredetiRaktar.Darabszam;

                            felhasznaltRaktarKeszlet.Add(new Raktar
                            {
                                RekeszId = eredetiRaktar.RekeszId,
                                AlkatreszId = eredetiRaktar.AlkatreszId,
                                AlkatreszNev = r.AlkatreszNev,
                                Darabszam = eredetiRaktar.Darabszam
                            });

                            _context.Raktar.Remove(eredetiRaktar);
                        }
                        else
                        {
                            felhasznaltRaktarKeszlet.Add(new Raktar
                            {
                                RekeszId = eredetiRaktar.RekeszId,
                                AlkatreszId = eredetiRaktar.AlkatreszId,
                                AlkatreszNev = r.AlkatreszNev,
                                Darabszam = hatralevoDb
                            });

                            eredetiRaktar.Darabszam -= hatralevoDb;
                            hatralevoDb = 0;
                        }
                    }
                }

                await _context.SaveChangesAsync();
                await adatbazisTranzakcio.CommitAsync();

                return Ok(felhasznaltRaktarKeszlet);
            }
            catch (Exception ex)
            {
                await adatbazisTranzakcio.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "szakember")]
        [HttpPut("arkalkulacio")]
        public async Task<IActionResult> Arkalkulacio(Projekt projekt)
        {
            using var adatbazisTranzakcio = await _context.Database.BeginTransactionAsync();

            try
            {
                var meglevoProjekt = await _context.Projektek.FindAsync(projekt.Id);

                if (meglevoProjekt == null)
                    return NotFound("Nincs ilyen projekt");

                if (projekt.Munkaido <= 0 || projekt.Munkadij <= 0)
                    return BadRequest("Munkaidő és munkadíj nagyobb kell legyen mint 0");

                var projektAlkatreszek = await _context.ProjektAlkatreszek
                    .Where(pa => pa.ProjektId == projekt.Id)
                    .ToListAsync();

                if (!projektAlkatreszek.Any())
                    return BadRequest("A projekthez nem tartozik alkatrész");

                if (projektAlkatreszek.Any(pa => pa.HianyDb > 0))
                    return BadRequest("Van hiányzó alkatrész");

                var alkatreszAr = await _context.ProjektAlkatreszek
                    .Where(pa => pa.ProjektId == projekt.Id)
                    .Join(_context.Alkatreszek,
                        pa => pa.AlkatreszId,
                        a => a.Id,
                        (pa, a) => new { pa, a })
                    .SumAsync(x => x.pa.Darabszam * x.a.Ar);

                meglevoProjekt.Ar = projekt.Munkadij * projekt.Munkaido + alkatreszAr;

                meglevoProjekt.Statusz = "Scheduled";

                var naplo = new Naplo
                {
                    ProjektId = meglevoProjekt.Id,
                    Statusz = meglevoProjekt.Statusz,
                    Datum = DateTime.UtcNow
                };

                _context.Naplok.Add(naplo);

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
    }
}