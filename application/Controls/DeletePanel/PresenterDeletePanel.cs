using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
