using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
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

            //Naplo letrehozasa
            var naplo = new Naplo
            {
                ProjektId = projekt.Id,
                Statusz = projekt.Statusz,
                Datum = DateTime.UtcNow
            };

            _context.Naplok.Add(naplo);
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

            //Projekt statuszanak beallitasa
            bool vanHiany = alkatreszLista.Any(a => a.HianyDb > 0);
            var projekt = await _context.Projektek.FindAsync(id);
            if (projekt == null)
                return NotFound("Projekt nem található");
            projekt.Statusz = vanHiany ? "Wait" : "Draft";

            // Naplo letrehozasa
            var naplo = new Naplo
            {
                ProjektId = projekt.Id,
                Statusz = projekt.Statusz,
                Datum = DateTime.UtcNow
            };

            _context.Naplok.Add(naplo);

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

                    var alkatreszNev = await _context.Alkatreszek
                        .Where(a => a.Id == pa.AlkatreszId)
                        .Select(a => a.Nev)
                        .FirstAsync();

                    var raktarLista = await _context.Raktar
                        .Where(r => r.AlkatreszId == pa.AlkatreszId)
                        .OrderBy(r => r.Darabszam)
                        .ToListAsync();

                    int osszes = raktarLista.Sum(r => r.Darabszam);

                    // hibakezelés
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
                                AlkatreszNev = alkatreszNev,
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
                                AlkatreszNev = alkatreszNev,
                                Darabszam = szuksegesDb
                            });

                            r.Darabszam -= szuksegesDb;
                            szuksegesDb = 0;
                        }
                    }
                }

                //Projekt statuszanak beallitasa
                var projekt = await _context.Projektek.FindAsync(id);
                if (projekt == null)
                {
                    await transaction.RollbackAsync();
                    return NotFound("Projekt nem található");
                }

                projekt.Statusz = "InProgress";

                // Naplo letrehozasa
                var naplo = new Naplo
                {
                    ProjektId = projekt.Id,
                    Statusz = projekt.Statusz,
                    Datum = DateTime.UtcNow
                };

                _context.Naplok.Add(naplo);

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

        //[Authorize(Roles = "szakember")]
        [HttpPut("{id}/arkalkulacio")]
        public async Task<IActionResult> Arkalkulacio(int id)
        {
            var meglevoProjekt = await _context.Projektek.FindAsync(id);

            if (meglevoProjekt == null)
                return NotFound("Nincs ilyen projekt");

            if (meglevoProjekt.Munkaido <= 0 || meglevoProjekt.Munkadij <= 0)
                return BadRequest("Munkaidő és munkadíj nagyobb kell legyen mint 0");

            bool vanAlkatresz = await _context.ProjektAlkatreszek
                .AnyAsync(pa => pa.ProjektId == id);

            if (!vanAlkatresz)
                return BadRequest("A projekthez nem tartozik alkatrész");

            bool vanHiany = await _context.ProjektAlkatreszek
                .AnyAsync(pa => pa.ProjektId == id && pa.HianyDb > 0);

            if (vanHiany)
                return BadRequest("Van hiányzó alkatrész");

            using var adatbazisTranzakcio = await _context.Database.BeginTransactionAsync();

            try
            {
                var alkatreszAr = await _context.ProjektAlkatreszek
                    .Where(pa => pa.ProjektId == id)
                    .Join(_context.Alkatreszek,
                        pa => pa.AlkatreszId,
                        a => a.Id,
                        (pa, a) => new { pa, a })
                    .SumAsync(x => x.pa.Darabszam * x.a.Ar);

                meglevoProjekt.Ar = meglevoProjekt.Munkadij * meglevoProjekt.Munkaido + alkatreszAr;
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