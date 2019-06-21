using System;
using System.Windows.Forms;

namespace application.Controls.AdminButtons
{
    class PresenterAdminControl
    {
        IAdminControl view;
        Model model;

        public PresenterAdminControl(IAdminControl view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.Load_SelectPanel += View_Load_SelectPanel;
            this.view.Load_InsertPanel += View_Load_InsertPanel;
            this.view.Load_DeletePanel += View_Load_DeletePanel;
            this.view.Load_UpdatePanel += View_Load_UpdatePanel;
        }

        private void View_Load_SelectPanel()
        {
            MFSingleton.Instance.view.PanelControl = model.Load_Select_Panel();
        }

        private void View_Load_InsertPanel()
        {
            MFSingleton.Instance.view.PanelControl = model.Load_Insert_Panel();
        }

        private void View_Load_DeletePanel()
        {
            MFSingleton.Instance.view.PanelControl = model.Load_Delete_Panel();
        }

        private void View_Load_UpdatePanel()
        {
            MFSingleton.Instance.view.PanelControl = model.Load_Update_Panel();
        }
    }
}
