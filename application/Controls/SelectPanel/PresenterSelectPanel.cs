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
        }

        private void View_GetItems()
        {
            this.view.Items = model.GetItems(this.view.Selected_Table);
        }
    }
}
