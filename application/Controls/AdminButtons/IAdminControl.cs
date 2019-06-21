using System;
using System.Windows.Forms;

namespace application.Controls.AdminButtons
{
    public interface IAdminControl
    {
        event Action Load_SelectPanel;
        event Action Load_InsertPanel;
        event Action Load_DeletePanel;
        event Action Load_UpdatePanel;
    }
}
