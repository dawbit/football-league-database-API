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
                this.InsertPresenter = new PresenterInsertPanel(view.InsertControl, model);
                this.DeletePresenter = new PresenterDeletePanel(view.DeleteControl, model);
                this.UpdatePresenter = new PresenterUpdatePanel(view.UpdateControl, model);
            }

            this.view.Load_SelectPanel += View_Load_SelectPanel;
            this.view.AdminControl.Load_SelectPanel += AdminControl_Load_SelectPanel;
            this.view.AdminControl.Load_InsertPanel += AdminControl_Load_InsertPanel;
            this.view.AdminControl.Load_DeletePanel += AdminControl_Load_DeletePanel;
            this.view.AdminControl.Load_UpdatePanel += AdminControl_Load_UpdatePanel;
        }

        private void AdminControl_Load_SelectPanel()
        {
            //this.view.Panel = new SelectPanel();
            this.view.Panel = (Control)this.view.SelectControl;
        }
        private void AdminControl_Load_InsertPanel()
        {
            this.view.Panel = (Control)this.view.InsertControl;
        }
        private void AdminControl_Load_DeletePanel()
        {
            this.view.Panel = (Control)this.view.DeleteControl;
        }
        private void AdminControl_Load_UpdatePanel()
        {
            this.view.Panel = (Control)this.view.UpdateControl;
        }

        private void View_Load_SelectPanel()
        {
            this.view.Panel = (Control)this.view.SelectControl;
        }
    }
}
