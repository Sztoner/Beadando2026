using Kliens.UserControls;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Text;

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

        private void Login(object sender, EventArgs e)
        {
            //Beléptetö kód majd ide

            RaktarvezetoMain rMain = new RaktarvezetoMain();
            LoadControl(rMain);
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