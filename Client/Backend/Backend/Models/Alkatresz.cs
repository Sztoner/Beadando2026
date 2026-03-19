
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

[Table("alkatresz")] 
public class Alkatresz
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nev")]
    public string Nev { get; set; }
    [Column("ar")]
    public int Ar { get; set; }
    [Column("maxdb")]
    public int MaxDb { get; set; }
}
