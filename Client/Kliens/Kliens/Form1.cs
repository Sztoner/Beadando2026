using Kliens.Shared;
using Kliens.UserControls;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Text;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Kliens
{
    public partial class Form1 : Form
    {
        public void LoadControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            while (mainPanel.Controls.Count > 0)
                mainPanel.Controls[0].Dispose();
            mainPanel.Controls.Add(uc);
        }

        private async void Login(object sender, EventArgs e)
        {
            var loginData = new
            {
                nev = nameBox.Text,
                jelszo = pwBox.Text
            };

            var json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try 
            {
                var response = await ApiKliens.Client.PostAsync("auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                    ApiKliens.SetJWTToken(result.token);
                    welcomeToolStripMenuItem.Visible = true;
                    welcomeToolStripMenuItem.Text = "Üdv, " + nameBox.Text;

                    string role = ApiKliens.GetRoleFromToken();
                    switch (role)
                    {
                        case "raktaros":
                            MessageBox.Show("Sikeres login!");
                            break;
                        case "szakember":
                            MessageBox.Show("Sikeres login!");
                            break;
                        case "raktarvezeto":
                            RaktarvezetoMain rMain = new RaktarvezetoMain();
                            LoadControl(rMain);
                            break;
                        default:
                            MessageBox.Show("Érvénytelen szerepkör!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                else MessageBox.Show("Hibás felhasználónév vagy jelszó", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}