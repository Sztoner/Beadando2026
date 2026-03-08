using Kliens.UserControls;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Text;
using System.Text;
using System.Text.Json;
using System.Text;
using Kliens.Shared;

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
            var response = await ApiKliens.Client.PostAsync("auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TokenResponse>(responseString);
                ApiKliens.SetJWTToken(result.token);

                string role = ApiKliens.GetRoleFromToken();
                switch (role)
                {
                    case "raktaros":
                        break;
                    case "szakember":
                        break;
                    case "raktarvezeto":
                        RaktarvezetoMain rMain = new RaktarvezetoMain();
                        LoadControl(rMain);
                        break;
                }

                //try
                //{
                //    var resp = await ApiKliens.Client.GetAsync("api/Alkatresz");

                //    if (resp.IsSuccessStatusCode)
                //    {
                //        var data = await resp.Content.ReadAsStringAsync();
                //        MessageBox.Show("Admin adat: " + data);
                //    }
                //    else
                //    {
                //        MessageBox.Show("Hozzáférés megtagadva: " + response.StatusCode);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Hiba a szerverrel: " + ex.Message);
                //}
            }
            else
            {
                MessageBox.Show("Hibás login");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}