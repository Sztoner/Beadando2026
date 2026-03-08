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
    [Column("two_factor_secret")]
    public string TwoFactorSecret { get; set; }
    [Column("two_factor_enabled")]
    public bool TwoFactorEnabled { get; set; }
}