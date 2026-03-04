using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kliens.Shared;

namespace Kliens.UserControls.Raktarvezeto
{
    public partial class UjAlkatresz : UserControl
    {
        public Alkatresz alkatresz = new Alkatresz();
        private void Cancel(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AddPart(object sender, EventArgs e)
        {
            if (nameBox.Text.Length >= 3 && priceBox.Value > 0 && rekeszdbBox.Value > 0)
            {
                alkatresz.Nev = nameBox.Text.Trim();
                alkatresz.Ar = (int)priceBox.Value;
                alkatresz.MaxDb = (int)rekeszdbBox.Value;
                //az uj alkatresz felvitele az adatbazisba

                MessageBox.Show(this.FindForm(), "Alkatrész sikeresen hozzáadva!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else MessageBox.Show(this.FindForm(), "Kérem érvényes adatokat adjon meg!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public UjAlkatresz()
        {
            InitializeComponent();
        }
    }
}
