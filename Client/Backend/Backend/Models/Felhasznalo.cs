using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations.Schema;

[Table("felhasznalo_adatok")]
 public class FelhasznaloAdatok
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nev")]
    public string Nev { get; set; }
    [Column("szerepkor")]
    public string Szerepkor { get; set; }
    [Column("jelszohash")]
    public string JelszoHash { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("two_factor_secret")]
    public int TwoFactorSecret { get; set; }
    [Column("two_factor_valid_date")]
    public DateTime TwoFactorValidDate { get; set; }
}