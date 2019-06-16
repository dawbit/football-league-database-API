using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Forms;

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

            DialogResult logResult = new FormLogin().ShowDialog();

            while (logResult != DialogResult.OK && logResult != DialogResult.Yes && logResult != DialogResult.Cancel)
            {
                logResult = new FormLogin().ShowDialog();
            }



            if (logResult == DialogResult.OK)
            {
                Application.Run(new FormAdmin());
            }
            else if (logResult == DialogResult.Yes)
            {
                Application.Run(new FormUser());
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
