using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("projekt")]
    public class Projekt
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nev")]
        public string Nev { get; set; }
        [Column("helyszin")]
        public string Helyszin { get; set; }
        [Column("megrendelo")]
        public string Megrendelo { get; set; }
        [Column("leiras")]
        public string Leiras { get; set; }
        [Column("statusz")]
        public string Statusz { get; set; }
        [Column("munkaido")]
        public int Munkaido { get; set; }
        [Column("munkadij")]
        public int Munkadij { get; set; }
        [Column("ar")]
        public int Ar { get; set; }
    }
}
