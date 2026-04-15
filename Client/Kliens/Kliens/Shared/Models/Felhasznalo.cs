using System;
using System.Collections.Generic;
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
        public string TwoFactorSecret { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
