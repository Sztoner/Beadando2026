using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.Shared
{
    public class FelhasznaloAdatok
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Szerepkor { get; set; }
        public string JelszoHash { get; set; }
        public string Email { get; set; }
        public int TwoFactorSecret { get; set; } = 0;
        public DateTime TwoFactorValidDate { get; set; } = DateTime.UtcNow;
    }
}
