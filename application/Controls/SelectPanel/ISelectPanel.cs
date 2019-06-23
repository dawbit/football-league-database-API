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
        object Selected_Item_Display { set; }
        List<List<string>> Items { get; set; }

        event Action<string> GetItems;
        event Action<string, int> ShowSelectedItem;
    }
}
