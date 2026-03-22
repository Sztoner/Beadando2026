using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("projekt_naplo")]
    public class Naplo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("projekt_id")]
        public int ProjektId { get; set; }
        [Column("statusz")]
        public string Statusz { get; set; }
        [Column("datum")]
        public DateTime Datum { get; set; }
    }
}
