using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Controls.AdminButtons;
using application.Controls.SelectPanel;
using application.Controls.InsertPanel;
using application.Controls.DeletePanel;
using application.Controls.UpdatePanel;

namespace application
{
    class MainFormPresenter
    {
        IMainForm view;
        Model model;

        PresenterAdminControl AdminPresenter;
        PresenterSelectPanel SelectPresenter;
        PresenterInsertPanel InsertPresenter;
        PresenterDeletePanel DeletePresenter;
        PresenterUpdatePanel UpdatePresenter;


        public MainFormPresenter(IMainForm view, Model model)
        {
            this.view = view;
            this.model = model;

            this.SelectPresenter = new PresenterSelectPanel(view.SelectControl, model);

            if (Program.AccountType == "administrator")
            {
                this.AdminPresenter = new PresenterAdminControl(view.AdminControl, model);

                this.InsertPresenter = new PresenterInsertPanel(view.InsertControl, model);
                this.DeletePresenter = new PresenterDeletePanel(view.DeleteControl, model);
                this.UpdatePresenter = new PresenterUpdatePanel(view.UpdateControl, model);
            }

            this.view.Load_SelectPanel += View_Load_SelectPanel;
        }

        private void View_Load_SelectPanel()
        {
            this.view.Panel = model.Load_Select_Panel();
        }
    }
}
