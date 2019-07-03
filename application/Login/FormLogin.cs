using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using application.DAL;

namespace application.Forms
{
    public partial class FormLogin : Form
    {
       public FormLogin()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.Text = String.Empty;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            textBoxPassword.PasswordChar = '*';
        }

        public string Login
        {
            get
            {
                return textBoxLogin.Text;
            }
            set
            {
                textBoxLogin.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return textBoxPassword.Text;
            }
        }

        private DBconnection _conn = DBconnection.Instance;
        private MySqlConnection _connection;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (Login != "" && Password != "")
            {
                int _result = DefineAccountType(Login, Password);

                Console.WriteLine(_result);

                if (_result == 0)
                {
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
                else if (_result == 1) DialogResult = DialogResult.Yes;

            }
        }

        private int DefineAccountType (string login, string password)
        {
            string Query = $"INSERT INTO ekstraklasa.logs(user, date) VALUES(\"{login}\", \"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\")";

            try
            {
                _conn = DBconnection.Init(login, password);
                _connection = _conn.Connection;

                using (MySqlCommand command = new MySqlCommand(Query, _connection))
                {
                    _connection.Open();

                    var dataReader = command.ExecuteNonQuery();

                    _connection.Close();

                    if (dataReader == 1) return 0;
                    else return 2;
                }
            }
            catch (MySqlException e)
            {
                _connection.Close();
                Console.WriteLine("ERROR: " + e.ToString());
                if (e.ToString().Contains("INSERT command denied to user")) return 1;
                else if (e.ToString().Contains("Authentication to host")) return 2;
                else return 2;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register.FormRegister frmRegister = new Register.FormRegister();
            frmRegister.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
