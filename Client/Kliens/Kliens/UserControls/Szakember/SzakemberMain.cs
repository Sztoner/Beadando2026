using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls.Szakember
{
    public partial class SzakemberMain : UserControl
    {
        public string[] statuses = {"New","Draft","Wait", "Scheduled", "InProgress", "Finished", "Failed"};
        public SzakemberMain()
        {
            InitializeComponent();
            laborcostBox.Controls[0].Visible = false;
            joblenghtBox.Controls[0].Visible = false;
        }
    }
}
