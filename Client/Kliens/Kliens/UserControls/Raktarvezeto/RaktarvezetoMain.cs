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
        //uj alkatresz hozzaadasa
        private void AddPart(object sender, EventArgs e)
        {
            UjAlkatresz ujAlkatresz = new UjAlkatresz();
            CenterControl(ujAlkatresz);
            mainPanel.Controls.Add(ujAlkatresz);
            ujAlkatresz.BringToFront();
        }

        //hatter engedelyezese miutan bezartuk az addpart ablakot
        public void EnableBackground(object sender, ControlEventArgs e)
        {
            if (mainPanel.Controls[0].Enabled == false)
            {
                foreach (Control c in mainPanel.Controls)
                    c.Enabled = true;
            }
        }

        //hatter deaktivalasa addig amig az addpart ablak lathato
        private void DisableBackground(object sender, ControlEventArgs e)
        {
            if (mainPanel.Controls.OfType<UjAlkatresz>().Any())
            {
                foreach (Control c in mainPanel.Controls)
                {
                    if (c != mainPanel.Controls.OfType<UjAlkatresz>().First())
                        c.Enabled = false;
                }
            }
        }

        //barmelyik control kepernyo kozepere helyezese
        private void CenterControl(Control c)
        {
            c.Location = new Point(mainPanel.Size.Width / 2 - c.Size.Width / 2, mainPanel.Size.Height / 2 - c.Size.Height / 2);
        }

        //addpart ablak kozepre helyezese ha lathato
        private void mainPanel_Resize(object sender, EventArgs e)
        {
            if (mainPanel.Controls.OfType<UjAlkatresz>().Any())
                CenterControl(mainPanel.Controls.OfType<UjAlkatresz>().First());
        }

        public RaktarvezetoMain()
        {
            InitializeComponent();
        }
    }
}
