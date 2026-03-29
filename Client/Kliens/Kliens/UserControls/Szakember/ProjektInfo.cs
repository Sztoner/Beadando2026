using Kliens.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls.Szakember
{
    public partial class ProjektInfo : UserControl
    {
        private int selectedId = 0;

        public List<string> statuses = new List<string> { "New", "Draft", "Wait", "Scheduled", "InProgress", "Finished", "Failed" };
        public Projekt selectedProject;
        public Action? OnClosing;



        private void AddParts(object sender, EventArgs e)
        {
            AlkatreszLefoglalas alkatreszLefoglalas = new AlkatreszLefoglalas(selectedProject);
            alkatreszLefoglalas.OnPartsAdded = async () => await UpdateProjektInfo();
            alkatreszLefoglalas.ShowDialog(this.FindForm());
        }

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
                LoadStatus();
            }
        }

        private void LoadStatus()
        { 
            if (statuses.Contains(selectedProject.Statusz))
            {
                statusLabel.Text = "Állapot: "+selectedProject.Statusz;
                int statusIndex = statuses.IndexOf(selectedProject.Statusz);
                if(statusIndex == 0)
                {
                    partGridView.Visible = false;
                    partsLabel.Text = "A Projekthez nem tartozik\nlefoglalt alkatrész";
                    PartsButton.Visible = true;
                }
                else if(statusIndex > 0 && statusIndex <= 3)
                {
                    partGridView.Visible = true;
                    partsLabel.Text = "Alkatrészek";
                    PartsButton.Visible = false;
                    LoadParts();
                }
            }
        }

        private async void LoadParts()
        {
            try
            {
                List<ProjektAlkatreszGet> projectParts = await ApiKliens.Client.GetFromJsonAsync<List<ProjektAlkatreszGet>>($"/api/Projekt/{selectedProject.Id}/alkatresz");
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

        private async void ProjektInfo_Load(object sender, EventArgs e)
        {
            await UpdateProjektInfo();
        }

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
                        string hiba = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Nem sikerült elmenti a változtatásokat", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                { MessageBox.Show(ex.ToString(), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally { ((Button)sender).Enabled = true; }
            }
        }

        private void GoBack(object sender, EventArgs e)
        {
            OnClosing?.Invoke();
            if(this.Parent != null)
                this.Parent.Controls.Remove(this);
            this.Dispose();
        }
        public ProjektInfo(int id)
        {
            InitializeComponent();
            selectedId = id;
        }
    }
}
