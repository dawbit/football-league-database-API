using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
