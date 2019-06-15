using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Login;

namespace application.Forms
{
    public enum AccountType
    {
        user,
        administrator
    };

    public partial class FormLogin : Form, ILogin
    {
        public FormLogin()
        {
            InitializeComponent();

            textBoxPassword.PasswordChar = '*';
            //this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
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
        public static AccountType type { get; set; }
        private string Account { get; set; }

        public event Func<string> LoginCheck;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (Login != "")
            {
                if (LoginCheck != null)
                {
                    Account = LoginCheck();
                    if (Check())
                    {
                        this.Close();
                    }
                }
            }
            
        }

        private bool Check()
        {
            Console.WriteLine(Account);
            if (Enum.IsDefined(typeof(AccountType), Account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Program.lstClosedForms.Add(this.Name);
        //}
    }
}
