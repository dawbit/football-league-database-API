using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.DeletePanel
{
    class PresenterDeletePanel
    {
        IDeletePanel view;
        Model model;

        public PresenterDeletePanel(IDeletePanel view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.GetItems += View_GetItems;
            this.view.ShowSelectedItem += View_ShowSelectedItem;
            this.view.DeleteRecord += View_DeleteRecord;
        }

        private void View_GetItems(string table)
        {
            this.view.Items = model.GetItems(this.view.Selected_Query_Records, table);
        }
        private void View_ShowSelectedItem(string table)
        {
            this.view.Selected_Item_Display = model.GetItem(this.view.GetSelectedItemIndex, table);
        }

        private void View_DeleteRecord(string table, int id)
        {
            bool result = model.DeleteRecord(table, id);
            this.view.Items = model.GetItems(this.view.Selected_Query_Records, table);
            if (result)
            {
                MessageBox.Show("Successfully deleted record!");
            }
            else
            {
                MessageBox.Show("There was an error. Check syntax.");
            }
        }
    }
}
