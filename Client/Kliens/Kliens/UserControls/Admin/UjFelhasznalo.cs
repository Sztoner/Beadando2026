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
using System.Web.Helpers;
using System.Windows.Forms;

namespace Kliens.UserControls.Admin
{
    public partial class UjFelhasznalo : Form
    {

        public Action? OnUserAdded;
        private async void CreateUser(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                if (nameBox.Text.Length <= 0 && emailBox.Text.Length <= 0 && pwBox.Text.Length <= 0)
                {
                    MessageBox.Show("Kérem minden mezöt töltsön ki!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rolesBox.SelectedItem is null)
                {
                    MessageBox.Show("Kérem válasszon szerepkört!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FelhasznaloAdatok newUser = new FelhasznaloAdatok
                {
                    Nev = nameBox.Text.Trim(),
                    Email = emailBox.Text.Trim(),
                    JelszoHash = BCrypt.Net.BCrypt.HashPassword(pwBox.Text),
                    Szerepkor = rolesBox.SelectedItem.ToString().ToLower()
                };

                var result = await ApiKliens.Client.PostAsJsonAsync<FelhasznaloAdatok>("/api/FelhasznaloAdatok", newUser);
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Nem sikerült a felhasználó létrehozása", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OnUserAdded?.Invoke();
                OnUserAdded = null;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { ((Button)sender).Enabled = true; }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        public UjFelhasznalo()
        {
            InitializeComponent();
        }
    }
}
