using Kliens.Shared;
using Kliens.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.WebPages;
using System.Windows.Forms;

namespace Kliens.UserControls
{
    public partial class TwoFA : Form
    {
        private string user = "";
        public Action? SuccessfulLogin;
        public TwoFA(string u)
        {
            InitializeComponent();
            user = u;
        }

        private async void SendVerifyRequest(object sender, EventArgs e)
        {
            TwoFactorVerifyRequest request = new TwoFactorVerifyRequest();
            request.Nev = user;
            if (int.TryParse(codeBox.Text, out int code))
                request.Code = code;
            else
            {
                MessageBox.Show("Kérem csak számot tartalmazó kódot adjon meg!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ((Button)sender).Enabled = false;
                var response = await ApiKliens.Client.PostAsJsonAsync<TwoFactorVerifyRequest>("/auth/verify2fa", request);
                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseContent, "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                if (result != null )
                    ApiKliens.SetJWTToken(result.token);
                else
                {
                    MessageBox.Show("Nem sikerült a komminukációs token beállítása", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SuccessfulLogin.Invoke();
                SuccessfulLogin = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { ((Button)sender).Enabled = true; }
        }
    }
}
