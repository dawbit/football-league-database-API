using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application
{
    interface IMainForm
    {
        Control PanelControl { get; set; }
        Controls.AdminButtons.IAdminControl AdminControl { get; }

        event Action Load_MenuPanel;
    }
}
