using Kliens.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls.Szakember
{
    public partial class ProjektInfo : UserControl
    {
        private int selectedId = 0;

        public List<string> statuses = new List<string> { "New", "Draft", "Wait", "Scheduled", "InProgress", "Completed", "Failed" };
        public Projekt selectedProject;
        public Action? OnClosing;


        //Projekt lefoglas form megjelenitese
        private void AddParts(object sender, EventArgs e)
        {
            AlkatreszLefoglalas alkatreszLefoglalas = new AlkatreszLefoglalas(selectedProject);
            alkatreszLefoglalas.OnPartsAdded = async () => await UpdateProjektInfo();
            alkatreszLefoglalas.ShowDialog(this.FindForm());
        }

        //Kivalasztott projekt betoltese
        private void LoadProject()
        {
            if (selectedProject != null)
            {
                //altalanos info
                nameLabel.Text = selectedProject.Nev;
                descriptionLabel.Text = selectedProject.Leiras;
                locationLabel.Text = selectedProject.Helyszin;
                clientLabel.Text = selectedProject.Megrendelo;
                laborcostBox.Value = selectedProject.Munkadij;
                joblenghtBox.Value = selectedProject.Munkaido;

                //Ha a munkaido es a munkadij mar rogzitesre kerult akkor a mentes gomb eltunetese
                if (selectedProject.Munkadij > 0 && selectedProject.Munkaido > 0)
                {
                    savePriceButton.Visible = false;
                    joblenghtBox.Enabled = false;
                    laborcostBox.Enabled = false;

                    calcPriceButton.Visible = true;
                    partPriceLabel.Visible = true;
                    priceLabel.Visible = true;
                }
                LoadStatus();
            }
        }

        //Kivalasztott projekt statuszanak betoltese
        private void LoadStatus()
        { 
            if (statuses.Contains(selectedProject.Statusz))
            {
                statusLabel.Text = "Állapot: "+selectedProject.Statusz;
                int statusIndex = statuses.IndexOf(selectedProject.Statusz);
                closeProjectButton.Visible = true;

                if(statusIndex == 0)
                {
                    partGridView.Visible = false;
                    partsLabel.Text = "A Projekthez nem tartozik\nlefoglalt alkatrész";
                    PartsButton.Visible = true;
                }
                else if(statusIndex > 0 && statusIndex < statuses.Count)
                {
                    partGridView.Visible = true;
                    partsLabel.Text = "Alkatrészek";
                    PartsButton.Visible = false;
                    LoadParts();

                    if (statusIndex >= 3)
                    {
                        calcPriceButton.Visible = false;
                        if (selectedProject.Ar > 0)
                        {
                            priceLabel.Text = "Össz. Ár: " + selectedProject.Ar.ToString() + "Ft";
                            partPriceLabel.Text = "Akatrészek Ára: " + (selectedProject.Ar - (selectedProject.Munkaido * selectedProject.Munkadij)).ToString() + "Ft";
                        }
                          
                        if(statusIndex >= 5)
                        {
                            closeProjectButton.Visible= false;
                            savePriceButton.Visible = false;
                            joblenghtBox.Enabled = false;
                            laborcostBox.Enabled = false;

                            partPriceLabel.Visible = true;
                            priceLabel.Visible = true;
                        }
                    }
                }
            }
        }

        //Ha a kivalasztott projekt megfelelo statuszban van a hozza tartozo alkatreszek betoltese
        private async void LoadParts()
        {
            try
            {
                List<ProjektAlkatreszGet> projectParts = await ApiKliens.Client.GetFromJsonAsync<List<ProjektAlkatreszGet>>($"/api/Projekt/{selectedProject.Id}/alkatresz");
                if (projectParts is null)
                    return;
                
                partGridView.DataSource = projectParts.Select(x => new
                {
                    x.AlkatreszNev,
                    x.Darabszam,
                    x.HianyDb
                }).ToList(); ;
                partGridView.Columns["Darabszam"].HeaderText = "Lefoglalt db";
                partGridView.Columns["HianyDb"].HeaderText = "Ebböl hiányzó";
                partGridView.Columns["AlkatreszNev"].HeaderText = "Alkatrész";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba,", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Projekt lekerese id alapjan
        private async Task UpdateProjektInfo()
        {
            try
            {
                selectedProject = await ApiKliens.Client.GetFromJsonAsync<Projekt>($"/api/Projekt/{selectedId}");
                LoadProject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //A munkadij es munkaido mentese
        private async void UpdatePriceInfo(object sender, EventArgs e)  
        {
            if(joblenghtBox.Value > 0 && laborcostBox.Value > 0)
            {
                selectedProject.Munkadij = (int)laborcostBox.Value;
                selectedProject.Munkaido = (int)joblenghtBox.Value;

                try
                {
                    ((Button)sender).Enabled = false;
                    var response = await ApiKliens.Client.PutAsJsonAsync<Projekt>("/api/Projekt", selectedProject);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Nem sikerült elmenti a változtatásokat", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LoadProject();
                }
                catch(Exception ex)
                { MessageBox.Show(ex.ToString(), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally { ((Button)sender).Enabled = true; }
            }
            else { MessageBox.Show("Kérem érvényes adatokat adjon meg!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        //Arkalkulacio elvegzese, allapot valtasa
        private async void CalculatePrice(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                var response = await ApiKliens.Client.PostAsync($"/api/Projekt/{selectedId}/arkalkulacio", null);

                if(!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await UpdateProjektInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { ((Button)sender).Enabled = true; };
        }

            #region Projekt lezarasa
        private async void CloseProject(object sender, EventArgs e)
        {
            if (selectedProject == null || !statuses.Contains(selectedProject.Statusz)) 
                return;

            int statusIndex = statuses.IndexOf(selectedProject.Statusz);
            string finalStatus = null;

            if (statusIndex < 4)
            {
                var valasz = MessageBox.Show(
                    "A projekt jelen állapotában csak Failed státuszban zárható le. Biztos folytatja?",
                    "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (valasz == DialogResult.Yes) finalStatus = "Failed";
            }
            else if (statusIndex == 4)
            {
                var valasz = MessageBox.Show(
                    "Sikeresen zárult a projekt?",
                    "Projekt lezárása", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (valasz == DialogResult.Yes) 
                    finalStatus = "Completed";
                else if (valasz == DialogResult.No) 
                    finalStatus = "Failed";
            }

            if (finalStatus != null)
            {
                ((Button)sender).Enabled= false;
                await CloserHelper(finalStatus);
                ((Button)sender).Enabled = true;
            }
        }

        private async Task CloserHelper(string statusz)
        {
            selectedProject.Statusz = statusz;
            try
            {
                var result = await ApiKliens.Client.PutAsJsonAsync<Projekt>($"/api/Projekt", selectedProject);
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("A projekt lezárása nem sikerült!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Naplo naplo = new Naplo
                {
                    ProjektId = selectedProject.Id,
                    Statusz = selectedProject.Statusz,
                    Datum = DateTime.UtcNow
                };

                var naploResult = await ApiKliens.Client.PostAsJsonAsync<Naplo>("/api/Projekt/Naplo", naplo);
                LoadStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //Vissza a SzakemberMainbe
        private void GoBack(object sender, EventArgs e)
        {
            OnClosing?.Invoke();
            if(this.Parent != null)
                this.Parent.Controls.Remove(this);
            OnClosing = null;
            this.Dispose();
        }

        private async void ProjektInfo_Load(object sender, EventArgs e)
        {
            await UpdateProjektInfo();
        }

        public ProjektInfo(int id)
        {
            InitializeComponent();
            selectedId = id;
        }
    }
}
