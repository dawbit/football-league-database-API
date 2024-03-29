﻿using System;
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
            this.view.Items = model.GetItems(this.view.Selected_Query_Records, table);
        }
        private void View_ShowSelectedItem(string table)
        {
            this.view.Selected_Item_Display = model.GetItem(this.view.GetSelectedItemIndex, table);
        }
    }
}
