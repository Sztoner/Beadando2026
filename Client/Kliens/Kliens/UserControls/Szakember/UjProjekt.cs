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
    public partial class UjProjekt : Form
    {
        public Action? OnProjectAdded;
        private async void CreateProject(object sender, EventArgs e)
        {
            if (nameBox.Text.Length > 0 && clientBox.Text.Length > 0 && locationBox.Text.Length > 0 && descriptionBox.Text.Length > 0)
            {
                Projekt newProject = new Projekt();
                newProject.Nev = nameBox.Text;
                newProject.Megrendelo = clientBox.Text;
                newProject.Leiras = descriptionBox.Text;
                newProject.Helyszin = locationBox.Text;
                newProject.Statusz = "New";

                try
                {
                    ((Button)sender).Enabled = false;
                    var response = await ApiKliens.Client.PostAsJsonAsync("/api/Projekt/", newProject);
                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(error, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    OnProjectAdded?.Invoke();
                    OnProjectAdded = null;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { ((Button)sender).Enabled = true; }
            }
            else MessageBox.Show("Kérem az összes mezöt töltse ki!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public UjProjekt()
        {
            InitializeComponent();
        }
    }
}
