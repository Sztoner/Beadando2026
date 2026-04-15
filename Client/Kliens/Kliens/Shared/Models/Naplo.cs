using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.Shared
{
    public class Naplo
    {
        public int Id { get; set; }
        public int ProjektId { get; set; }
        public string Statusz { get; set; }
        public DateTime Datum { get; set; }
    }

}
