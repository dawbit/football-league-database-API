using application.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Register
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.Text = String.Empty;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            tbPassword.PasswordChar = '*';
            tbRepeatPassword.PasswordChar = '*';
        }

        private DBconnection _connection = null;

        private string UserName
        {
            get
            {
                return tbUserName.Text;
            }
        }

        private string Password
        {
            get
            {
                return tbPassword.Text;
            }
        }

        private string RepeatedPassword
        {
            get
            {
                return tbRepeatPassword.Text;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (Password == RepeatedPassword)
            {
                Dictionary<string, object>  par = new Dictionary<string, object>
                {
                    { "@username", UserName },
                    { "@password", Password }
                };

                string Query = $"CREATE USER { UserName }@localhost IDENTIFIED BY '{ Password }';" +
                    $"GRANT SELECT ON ekstraklasa.* TO { UserName }@localhost;";

                 _connection = DBconnection.Init("root", "");
                bool result = _connection.CreateUser(Query);
                if (result)
                {
                    MessageBox.Show($"Successfully created a new user { UserName }");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Could not created a new user");
                }
            }
            else
            {
                MessageBox.Show("Passwords must match");
            }
        }
    }
}
