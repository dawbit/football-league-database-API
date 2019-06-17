using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace application.UserControls
{
    public partial class MainMenuPanel : UserControl
    {
        public MainMenuPanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelLogo, new object[] { true });
        }

        private void mainPanelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
