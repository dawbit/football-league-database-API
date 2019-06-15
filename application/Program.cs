using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Forms;
using application.Login;

namespace application
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);


            Model model = new Model();
            ILogin viewLogin = new FormLogin();
            LoginPanelPresenter presenter = new LoginPanelPresenter(viewLogin, model);

            DialogResult logResult = ((FormLogin)viewLogin).ShowDialog();
            while (logResult != DialogResult.OK)
            {
                logResult = ((FormLogin)viewLogin).ShowDialog();
            }

            if (logResult == DialogResult.OK)
            {
                Console.WriteLine("?");
            }
            
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Are You Sure To Exit?", "ExitConfirmation", MessageBoxButtons.OKCancel))
            {
                if (Application.MessageLoop)
                    Application.Exit();
                else
                    Environment.Exit(1);
            }
        }
    }
}
