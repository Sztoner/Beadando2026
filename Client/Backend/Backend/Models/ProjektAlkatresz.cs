using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("projekt_alkatresz")]
    public class ProjektAlkatresz
    {
        [Column("projekt_id")]
        public int ProjektId { get; set; }
        [Column("alkatresz_id")]
        public int AlkatreszId { get; set; }
        [Column("darabszam")]
        public int Darabszam { get; set; }
        [Column("hianydb")]
        public int HianyDb { get; set; }
    }
}
