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

namespace Kliens.UserControls.Raktaros
{
    public partial class RaktarosMain : UserControl
    {

        private async Task UpdateProjectsBox()
        {
            try
            {
                projectsBox.DataSource = null;
                List<Projekt> projects = await ApiKliens.Client.GetFromJsonAsync<List<Projekt>>("/api/Projekt/scheduled");

                if (projects != null)
                {
                    projectsBox.DataSource = projects;
                    projectsBox.DisplayMember = "Nev";
                    projectsBox.Enabled = true;
                }
                else projectsBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ExecuteProject(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            if (projectsBox.SelectedItem is not Projekt)
            {
                MessageBox.Show("Válasszon ki egy projektet!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ((Button)sender).Enabled = true;
                return;
            }

            warehouseBox.DataSource = null;
            try
            {
                int pId = (projectsBox.SelectedItem as Projekt).Id;
                var response = await ApiKliens.Client.PostAsync($"/api/Projekt/{pId}/kivitelez", null);

                if (!response.IsSuccessStatusCode)
                {
                    var hiba = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(hiba, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedParts = await response.Content
                    .ReadFromJsonAsync<List<Raktar>>();

                if (selectedParts != null)
                {
                    selectedParts = selectedParts
                        .OrderBy(x => int.Parse(x.RekeszId.Split(',')[0]))
                        .ThenBy(x => int.Parse(x.RekeszId.Split(',')[1]))
                        .ThenBy(x => int.Parse(x.RekeszId.Split(',')[2]))
                        .ToList();

                    warehouseBox.DataSource = selectedParts.Select(x => new
                    {
                        x.RekeszId,
                        x.AlkatreszNev,
                        x.Darabszam
                    }).ToList();
                    warehouseBox.Columns["RekeszId"].HeaderText = "Pozíció";
                    warehouseBox.Columns["AlkatreszNev"].HeaderText = "Név";
                    warehouseBox.Columns["Darabszam"].HeaderText = "Kiveendö darabszám";

                    await UpdateProjectsBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ((Button)sender).Enabled = true;
            }

        }


        private async void updateButton_Click(object sender, EventArgs e)
        {
            await UpdateProjectsBox();
        }

        public RaktarosMain()
        {
            InitializeComponent();
        }

        private async void RaktarosMain_Load(object sender, EventArgs e)
        {
            await UpdateProjectsBox();
        }
    }
}
