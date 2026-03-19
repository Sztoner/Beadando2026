using Kliens.Shared;
using Kliens.UserControls.Raktarvezeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls
{
    public partial class RaktarvezetoMain : UserControl
    {
        public List<Alkatresz> alkatreszek = new List<Alkatresz>();
        public Alkatresz selectedAlkatresz = new Alkatresz();

        //uj alkatresz hozzaadasa
        private void ShowAddPartDialog(object sender, EventArgs e)
        {
            UjAlkatresz ujAlkatresz = new UjAlkatresz();
            ujAlkatresz.OnPartAdded = async () => await UpdatePartBox();
            mainPanel.Controls.Add(ujAlkatresz);
            ujAlkatresz.CenterControl();
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

        //addpart ablak kozepre helyezese ha lathato
        private void mainPanel_Resize(object sender, EventArgs e)
        {
            if (mainPanel.Controls.OfType<UjAlkatresz>().Any())
                mainPanel.Controls.OfType<UjAlkatresz>().First().CenterControl();
        }

        //PartBox frissitese ha megnyilik a usercontrol
        private async void RaktarvezetoMain_Load(object sender, EventArgs e)
        {
            await UpdatePartBox();
        }

        public async Task UpdatePartBox()
        {
            try
            {
                alkatreszek = await ApiKliens.Client.GetFromJsonAsync<List<Alkatresz>>("api/Alkatresz");
                partBox.DataSource = alkatreszek;
                partBox.DisplayMember = "Nev";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Kiválásztott alkatrész adatainak betöltése
        private void partBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedAlkatresz = (Alkatresz)partBox.SelectedItem;

            if(selectedAlkatresz != null)
            {
                //alkatresz adatainak beallitasa
                partNameLabel.Text = selectedAlkatresz.Nev;
                partIdLabel.Text = selectedAlkatresz.Id.ToString();
                priceBox.Value = selectedAlkatresz.Ar;
                dbBox.Value = selectedAlkatresz.MaxDb;
            }
        }

        public async void UpdatePart(object sender, EventArgs e)
        {
            if (selectedAlkatresz != null)
            {
                if (priceBox.Value > 0 && dbBox.Value > 0)
                {
                    selectedAlkatresz.Ar = (int)priceBox.Value;
                    selectedAlkatresz.MaxDb = (int)dbBox.Value;

                    try
                    {
                        var response = await ApiKliens.Client.PutAsJsonAsync($"api/Alkatresz/{selectedAlkatresz.Id}", selectedAlkatresz);

                        if (!response.IsSuccessStatusCode)
                        {
                            string hiba = await response.Content.ReadAsStringAsync();
                            MessageBox.Show(hiba, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else MessageBox.Show("Kérem érvényes adatokat adjon meg!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else MessageBox.Show("Kérem válasszon ki egy alkatrészt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public RaktarvezetoMain()
        {
            InitializeComponent();
            filterBox.SelectedIndex = 0;
        }
    }
}
