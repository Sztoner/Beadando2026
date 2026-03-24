using Kliens.Shared;
using Kliens.UserControls.Raktarvezeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls.Szakember
{
    public partial class SzakemberMain : UserControl
    {
        public List<Projekt> projects;

        private void AddProject(object sender, EventArgs e)
        {
            UjProjekt ujProjekt = new UjProjekt();
            ujProjekt.OnProjectAdded = async () => await UpdateProjectsBox();
            ujProjekt.ShowDialog(this.FindForm());
        }


        private async Task UpdateProjectsBox()
        {
            try
            {
                projects = await ApiKliens.Client.GetFromJsonAsync<List<Projekt>>("api/Projekt");
                projects = projects.OrderBy(x => x.Id).ToList();

                projectsGridView.DataSource = projects.Select(x => new
                {
                    x.Id,
                    x.Nev,
                    x.Helyszin,
                    x.Megrendelo,
                    x.Statusz
                }).ToList();
                projectsGridView.Columns["Id"].HeaderText = "Azonosító";
                projectsGridView.Columns["Nev"].HeaderText = "Név";
                projectsGridView.Columns["Helyszin"].HeaderText = "Helyszín";
                projectsGridView.Columns["Megrendelo"].HeaderText = "Megrendelö";
                projectsGridView.Columns["Statusz"].HeaderText = "Státusz";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProject(object sender, EventArgs e)
        {
            int projectId = (int)projectsGridView.SelectedRows[0].Cells[0].Value;
            Debug.WriteLine(projectId);
            ProjektInfo pInfo = new ProjektInfo(projectId);
            pInfo.OnClosing = async () => await UpdateProjectsBox(); 
            mainPanel.Controls.Add(pInfo);
            pInfo.Dock = DockStyle.Fill;
            pInfo.BringToFront();
        }

        public SzakemberMain()
        {
            InitializeComponent();
            projectsGridView.MultiSelect = false;
        }

        private async void SzakemberMain_Load(object sender, EventArgs e)
        {
            await UpdateProjectsBox();
        }
    }
}
