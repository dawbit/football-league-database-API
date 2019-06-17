using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Forms;
using application.UserControls;

namespace application
{
    public partial class FormMain : Form, MainFormView
    {
        public FormMain()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.ControlBox = false;
            this.Text = String.Empty;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, mainApplicationPanel, new object[] { true });


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
            return;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MainMenuPanel panel = new MainMenuPanel();
            mainApplicationPanel.Controls.Add(panel);

            if (Program.AccountType == "administrator")
            {
                AdminControls adminControl = new AdminControls();
                adminControl.Location = new Point(959, 12);
                this.Controls.Add(adminControl);
            }
        }
    }
}
