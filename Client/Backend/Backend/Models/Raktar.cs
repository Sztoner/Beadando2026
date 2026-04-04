using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("raktar")]
    public class Raktar
    {
        [Key]
        [Column("rekeszid")]
        public string RekeszId { get; set; }
        [Column("alkatresz_id")]
        public int AlkatreszId { get; set; }
        [NotMapped]
        public string? AlkatreszNev { get; set; }
        [Column("darabszam")]
        public int Darabszam { get; set; }
    }
}
