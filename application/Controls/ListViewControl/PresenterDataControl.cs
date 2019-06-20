using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controls.ListViewControl
{
    class PresenterDataControl
    {
        IDataControl view;
        Model model;

        public PresenterDataControl(IDataControl view, Model model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
