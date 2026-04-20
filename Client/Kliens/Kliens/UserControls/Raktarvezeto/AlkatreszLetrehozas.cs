using Kliens.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls.Raktarvezeto
{
    public partial class AlkatreszLetrehozas : Form
    {
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddPart(object sender, EventArgs e)
        {
            Alkatresz alkatresz = new Alkatresz();
            if (nameBox.Text.Length > 0 && priceBox.Value > 0 && rekeszdbBox.Value > 0)
            {
                alkatresz.Nev = nameBox.Text.Trim();
                alkatresz.Ar = (int)priceBox.Value;
                alkatresz.MaxDb = (int)rekeszdbBox.Value;
                //az uj alkatresz felvitele az adatbazisba
                try
                {
                    ((Button)sender).Enabled = false;
                    var response = await ApiKliens.Client.PostAsJsonAsync("api/Alkatresz", alkatresz);
                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(error, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    OnPartAdded?.Invoke();
                    OnPartAdded = null;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { ((Button)sender).Enabled = true; }
            }
            else MessageBox.Show("Kérem minden mezöt tötlsön ki!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public Action? OnPartAdded;
        public AlkatreszLetrehozas()
        {
            InitializeComponent();
        }
    }
}
