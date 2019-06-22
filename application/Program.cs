using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string AccountType;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult logResult = new FormLogin().ShowDialog();

            while (logResult != DialogResult.OK && logResult != DialogResult.Yes && logResult != DialogResult.Cancel)
            {
                logResult = new FormLogin().ShowDialog();
            }

            if (logResult == DialogResult.OK || logResult == DialogResult.Yes)
            {
                if (logResult == DialogResult.OK) AccountType = "administrator";
                else AccountType = "user";

                Model model = new Model();
                IMainForm view = new FormMain();
                MainFormPresenter presenter = new MainFormPresenter(view, model);
                Application.Run((FormMain)view);
            } 
        }
    }
}
