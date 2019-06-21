using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using application.DAL;
using System.Windows.Forms;
using application.Controls;

namespace application
{
    class Model
    {
        public Model() { }

        public Control Load_Menu_Panel()
        {
            return new MainMenuPanel();
        }

        public Control Load_Select_Panel()
        {
            Console.WriteLine("ZOSTAŁEM WYWOŁANY");
            return new Controls.SelectPanel.SelectPanel();
        }

        public Control Load_Insert_Panel()
        {
            return new Controls.InsertPanel.InsertPanel();
        }

        public Control Load_Delete_Panel()
        {
            return new Controls.DeletePanel.DeletePanel();
        }

        public Control Load_Update_Panel()
        {
            return new Controls.UpdatePanel.UpdatePanel();
        }
    }
}
