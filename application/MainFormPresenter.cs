using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Controls;

namespace application
{
    class MainFormPresenter
    {
        IMainForm view;
        Model model;

        Controls.AdminButtons.PresenterAdminControl AdminPresenter;

        public MainFormPresenter(IMainForm view, Model model)
        {
            this.view = view;
            this.model = model;

            Console.WriteLine(view.AdminControl.ToString());
            this.AdminPresenter = new Controls.AdminButtons.PresenterAdminControl(view.AdminControl, model);

            this.view.Load_MenuPanel += View_Load_MenuPanel;
        }

        private void View_Load_MenuPanel()
        {
            this.view.PanelControl = model.Load_Menu_Panel();
        }
    }
}
