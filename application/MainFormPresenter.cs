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

            this.AdminPresenter = new Controls.AdminButtons.PresenterAdminControl(view.AdminControl, model);

            //this.MenuPresenter = new Controls.MenuPanel.PresenterMenuPanel()

            this.view.Load_SelectPanel += View_Load_SelectPanel;
        }

        private void View_Load_SelectPanel()
        {
            this.view.PanelControl = model.Load_Select_Panel();
        }
    }
}
