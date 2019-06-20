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
        List<Control> PanelControls { set; }
    }
}
