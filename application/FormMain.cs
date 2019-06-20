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
        #region Function for double buffering
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            PropertyInfo prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            prop.SetValue(c, true, null);
        }

        #endregion

        #region Flucuring

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

        public List<Control> PanelControls
        {
            set
            {
                mainApplicationPanel.Controls.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    mainApplicationPanel.Controls.Add(value[i]);
                }
            }
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
            List<Control> objects = new List<Control>();
            objects.Add(panel);
            PanelControls = objects;

            if (Program.AccountType == "administrator")
            {
                AdminControls adminControl = new AdminControls();
                adminControl.Location = new Point(959, 12);
                this.Controls.Add(adminControl);
            }
        }
    }
}
