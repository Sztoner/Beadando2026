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
            ((Button) sender).Enabled = false;
            warehouseBox.DataSource = null;
            if (projectsBox.SelectedItem is not Projekt)
            {
                MessageBox.Show("Válasszon ki egy projektet!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ((Button)sender).Enabled = true;
                return;
            }

            try
            {
                int pId = (projectsBox.SelectedItem as Projekt).Id;
                List<Raktar> selectedParts = await ApiKliens.Client.GetFromJsonAsync<List<Raktar>>($"/api/Projekt/{pId}/kivitelez");

                if(selectedParts != null)
                {
                    selectedParts = selectedParts
                        .OrderBy(x => int.Parse(x.RekeszId.Split(',')[0]))
                        .ThenBy(x => int.Parse(x.RekeszId.Split(',')[1]))
                        .ThenBy(x => int.Parse(x.RekeszId.Split(',')[2]))
                        .ToList();

                    warehouseBox.DataSource = selectedParts;
                    warehouseBox.Columns["RekeszId"].HeaderText = "Pozíció";
                    warehouseBox.Columns["AlkatreszNev"].HeaderText = "Név";
                    warehouseBox.Columns["Darabszam"].HeaderText = "Kiveendö darabszám";

                    await UpdateProjectsBox();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ((Button)sender).Enabled = true;
            }

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
