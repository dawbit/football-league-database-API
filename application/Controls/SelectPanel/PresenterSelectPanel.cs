using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controls.SelectPanel
{
    class PresenterSelectPanel
    {
        ISelectPanel view;
        Model model;

        public PresenterSelectPanel(ISelectPanel view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.GetItems += View_GetItems;
            this.view.ShowSelectedItem += View_ShowSelectedItem;
        }

        private void View_GetItems(string table)
        {
            if (table == "Players") this.view.Items = model.GetPlayers(this.view.Selected_Query_Records).Cast<object>().ToList();
            if (table == "Clubs") this.view.Items = model.GetClubs(this.view.Selected_Query_Records).Cast<object>().ToList();
            if (table == "Coaches") this.view.Items = model.GetCoaches(this.view.Selected_Query_Records).Cast<object>().ToList();
            if (table == "Kits") this.view.Items = model.GetKits(this.view.Selected_Query_Records).Cast<object>().ToList();
        }
        private void View_ShowSelectedItem(string table, int id)
        {
            if (table == "Players") this.view.Selected_Item_Display = model.GetPlayer(id);
            if (table == "Clubs") this.view.Selected_Item_Display = model.GetClub(id);
            if (table == "Coaches") this.view.Selected_Item_Display = model.GetCoach(id);
            if (table == "Kits") this.view.Selected_Item_Display = model.GetKit(id);
        }
    }
}
