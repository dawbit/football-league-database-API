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

        #region Load Selected Panels
        public Control Load_Select_Panel()
        {
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
        #endregion

        public void ChoosenOption(string option)
        {

            Console.WriteLine(option);
        }
    }
}
