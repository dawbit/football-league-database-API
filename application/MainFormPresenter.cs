using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class MainFormPresenter
    {
        MainFormView view;
        Model model;

        public MainFormPresenter(MainFormView view, Model model)
        {
            this.view = view;
            this.model = model;

        }
    }
}
