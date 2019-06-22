using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controls.SelectPanel
{
    public interface ISelectPanel
    {
        string Selected_Table { get; }
        List<Tuple<string, string>> Selected_Item_Display { set; }
    }
}
