using Kliens.UserControls;
using System.Drawing.Text;

namespace Kliens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login(object sender, EventArgs e)
        {
            //Beléptetö kód majd ide

            RaktarvezetoMain rMain = new RaktarvezetoMain();
            rMain.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(rMain);

        }
    }
}