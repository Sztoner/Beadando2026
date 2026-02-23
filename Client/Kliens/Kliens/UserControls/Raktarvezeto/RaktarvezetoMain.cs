using Kliens.UserControls.Raktarvezeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls
{
    public partial class RaktarvezetoMain : UserControl
    {
        private void AddPart(object sender, EventArgs e)
        {
            UjAlkatresz ujAlkatresz = new UjAlkatresz();
            CenterControl(ujAlkatresz);
            mainPanel.Controls.Add(ujAlkatresz);
            ujAlkatresz.BringToFront();
        }

        private void CenterControl(Control c)
        {
            c.Location = new Point(mainPanel.Size.Width / 2 - c.Size.Width / 2, mainPanel.Size.Height / 2 - c.Size.Height / 2);
        }

        public RaktarvezetoMain()
        {
            InitializeComponent();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            if(mainPanel.Controls.OfType<UjAlkatresz>().Any())
                CenterControl(mainPanel.Controls.OfType<UjAlkatresz>().First());
        }
    }
}
