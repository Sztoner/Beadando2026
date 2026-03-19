using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.Shared
{
    public static class Methods
    {
        public static void CenterControl(this Control c)
        {
            if (c.Parent != null)
                c.Location = new Point(c.Parent.Size.Width / 2 - c.Size.Width / 2, c.Parent.Size.Height / 2 - c.Size.Height / 2);
        }
    }
}
