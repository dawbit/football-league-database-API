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
    interface IMainForm
    {
        Control Panel { get; set; }

        IAdminControl AdminControl { get; }
        ISelectPanel SelectControl { get; }
        IInsertPanel InsertControl { get; }
        IDeletePanel DeleteControl { get; }
        IUpdatePanel UpdateControl { get; }

        event Action Load_SelectPanel;
    }
}
