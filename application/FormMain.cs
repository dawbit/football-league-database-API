using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using application.Controls.AdminButtons;
using application.Controls.SelectPanel;
using application.Controls.InsertPanel;
using application.Controls.DeletePanel;
using application.Controls.UpdatePanel;


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

        private bool init = true;

        public FormMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.ControlBox = false;
            this.Text = String.Empty;
        }

        #region IView
        public string CurrentControl
        {
            get
            {
                List<Control> ControlList = new List<Control>();
                foreach (Control c in this.Controls)
                    ControlList.Add(c);

                return ControlList[ControlList.Count - 1].Name;
            }
        }

        public Control Panel
        {
            get
            {
                return this.Controls[this.Controls.Count - 1];
            }
            set
            {
                if (init == true) init = false;
                    else this.Controls.RemoveAt(this.Controls.Count - 1);

                SetDoubleBuffered(value);
                value.Location = new Point(12, 59);
                this.Controls.Add(value);
            }
        }

        private AdminControls adminControl = new AdminControls();

        private SelectPanel selectPanel = new SelectPanel();
        private InsertPanel insertPanel = new InsertPanel();
        private DeletePanel deletePanel = new DeletePanel();
        private UpdatePanel updatePanel = new UpdatePanel();

        public IAdminControl AdminControl
        {
            get
            {
                return adminControl;
            }
        }
        public ISelectPanel SelectControl
        {
            get
            {
                return selectPanel;
            }
        }
        public IInsertPanel InsertControl
        {
            get
            {
                return insertPanel;
            }
        }
        public IDeletePanel DeleteControl
        {
            get
            {
                return deletePanel;
            }
        }
        public IUpdatePanel UpdateControl
        {
            get
            {
                return updatePanel;
            }
        }

        public event Action Load_SelectPanel;
        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Program.AccountType == "administrator")
            {
                adminControl.Location = new Point(959, 12);
                this.Controls.Add(adminControl);
            }

            Load_SelectPanel?.Invoke();

            foreach (Control c in this.Controls)
            {
                Console.WriteLine(c.ToString());
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
