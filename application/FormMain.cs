using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using application.Controls;
using application.Controls.AdminButtons;

namespace application
{
    public partial class FormMain : Form, IMainForm
    {
        #region Function for double buffering, flucuring
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            PropertyInfo prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            prop.SetValue(c, true, null);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= 0x02000000;
                return parameters;
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

        public Control PanelControl
        {
            get
            {
                Control control = new Control();
                foreach (Control obj in mainApplicationPanel.Controls)
                {
                    control = obj;
                }
                return control;
            }
            set
            {
                mainApplicationPanel.Controls.Clear();
                SetDoubleBuffered(value); // wywołaj funkcje dla kontenera która naprawi problem migotania
                mainApplicationPanel.Controls.Add(value);
            }
        }

        private AdminControls adminControl = new AdminControls();

        public IAdminControl AdminControl
        {
            get
            {
                return adminControl;
            }
        }

        public event Action Load_SelectPanel;

        private void FormMain_Load(object sender, EventArgs e)
        {
            Load_SelectPanel?.Invoke();

            if (Program.AccountType == "administrator")
            {
                adminControl.Location = new Point(959, 12);
                this.Controls.Add(adminControl);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
            return;
        }
    }
}
