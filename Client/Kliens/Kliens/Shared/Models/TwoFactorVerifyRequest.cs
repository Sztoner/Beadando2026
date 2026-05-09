using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.Shared.Models
{
    internal class TwoFactorVerifyRequest
    {
        public string Nev { get; set; }
        public int Code { get; set; }
    }
}
