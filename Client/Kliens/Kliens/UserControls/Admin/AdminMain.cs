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

namespace Kliens.UserControls.Admin
{
    public partial class AdminMain : UserControl
    {

        private async Task LoadUsers()
        {
            try
            {
                var users = await ApiKliens.Client.GetFromJsonAsync<List<FelhasznaloGet>>("/api/FelhasznaloAdatok");

                if (users is List<FelhasznaloGet>)
                {
                    usersGridView.DataSource = users.OrderBy(x => x.Id).ToList();

                    usersGridView.Columns["Id"].HeaderText = "Azonosító";
                    usersGridView.Columns["Nev"].HeaderText = "Név";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewUser(object sender, EventArgs e)
        {
            UjFelhasznalo ujFelhasznalo = new UjFelhasznalo();
            ujFelhasznalo.OnUserAdded = async () => await LoadUsers();
            ujFelhasznalo.ShowDialog();
        }

        private async void DeleteUser(object sender, EventArgs e)
        {
            try
            {
                int uid;
                if (usersGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Kérem válasszon ki egy felhaszálót!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                
                uid = (int)usersGridView.SelectedRows[0].Cells[0].Value;
                var result = await ApiKliens.Client.DeleteAsync($"/api/FelhasznaloAdatok/{uid}");

                if(!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Nem sikerült a felhasználó törlése", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoadUsers();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AdminMain()
        {
            InitializeComponent();
        }

        private async void AdminMain_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }
    }
}
