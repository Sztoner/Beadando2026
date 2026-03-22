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
    public partial class SzakemberMain : UserControl
    {
        public string[] statuses = { "New", "Draft", "Wait", "Scheduled", "InProgress", "Finished", "Failed" };
        public Projekt selectedProject;
        public List<Projekt> projects;

        private void AddProject(object sender, EventArgs e)
        {
            UjProjekt ujProjekt = new UjProjekt();
            ujProjekt.ShowDialog(this.FindForm());
            ujProjekt.OnProjectAdded = async () => { await UpdateProjectBox(); };
        }

        private async Task UpdateProjectBox()
        {
            try
            {
                projects = await ApiKliens.Client.GetFromJsonAsync<List<Projekt>>("/api/Projekt");
                projectBox.DataSource = projects;
                projectBox.DisplayMember = "Nev";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SzakemberMain_Load(object sender, EventArgs e)
        {
            await UpdateProjectBox();
        }

        public SzakemberMain()
        {
            InitializeComponent();
            laborcostBox.Controls[0].Visible = false;
            joblenghtBox.Controls[0].Visible = false;
        }
    }
}
