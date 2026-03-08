using Microsoft.EntityFrameworkCore;

public class PostgreDbContext : DbContext
{
    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
    }

    public DbSet<Alkatresz> Alkatreszek { get; set; }
    public DbSet<FelhasznaloAdatok> Felhasznalok { get; set; }
}