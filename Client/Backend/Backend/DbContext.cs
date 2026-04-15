using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class PostgreDbContext : DbContext
{
    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
    }

    public DbSet<Alkatresz> Alkatreszek { get; set; }
    public DbSet<FelhasznaloAdatok> Felhasznalok { get; set; }
    public DbSet<Raktar> Raktar { get; set; }
    public DbSet<Projekt> Projektek { get; set; }
    public DbSet<ProjektAlkatresz> ProjektAlkatreszek { get; set; }
    public DbSet<Naplo> Naplok { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjektAlkatresz>()
            .HasKey(pa => new { pa.ProjektId, pa.AlkatreszId });
    }
}