using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using application.Controls;

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

        private Controls.AdminButtons.AdminControls adminControl = new Controls.AdminButtons.AdminControls();

        public Controls.AdminButtons.IAdminControl AdminControl
        {
            get
            {
                Console.WriteLine("IAdminControl AdminControl");
                return adminControl;
            }
}

        public event Action Load_MenuPanel;


        private void FormMain_Load(object sender, EventArgs e)
        {
            Load_MenuPanel?.Invoke();

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

        private void buttonMenuPanel_Click(object sender, EventArgs e)
        {
            Load_MenuPanel?.Invoke();
        }
    }
}
