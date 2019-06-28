using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.InsertPanel
{
    class PresenterInsertPanel
    {
        IInsertPanel view;
        Model model;

        public PresenterInsertPanel(IInsertPanel view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.GetItems += View_GetItems;
            this.view.InsertRecord += View_InsertRecord;
        }

        private void View_GetItems(string table)
        {
            this.view.Items = model.GetItems(this.view.Selected_Query_Records, table);
        }

        private void View_InsertRecord(string table)
        {
            bool result = model.InsertRecord(this.view.Insert_Item, table);
            this.view.Items = model.GetItems(this.view.Selected_Query_Records, table);
            if (result)
            {
                MessageBox.Show("Successfully added new record!");
            }
            else
            {
                MessageBox.Show("There was an error. Check syntax.");
            }
        }
    }
}
