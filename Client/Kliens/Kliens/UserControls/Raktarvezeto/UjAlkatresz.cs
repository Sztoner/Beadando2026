using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls.Raktarvezeto
{
    public partial class UjAlkatresz : UserControl
    {
        private void Cancel(object sender, EventArgs e)
        {
            this.Dispose();        }
        
        public UjAlkatresz()
        {
            InitializeComponent();
        }
    }
}
