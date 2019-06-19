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
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion


        public FormMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.ControlBox = false;
            this.Text = String.Empty;
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
            SetDoubleBuffered(panel); // wywołaj funkcje dla kontenera która naprawi problem migotania
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
