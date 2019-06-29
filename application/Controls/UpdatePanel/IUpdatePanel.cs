using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controls.UpdatePanel
{
    public interface IUpdatePanel
    {
        string Selected_Table { get; }
        int GetSelectedItemIndex { get; }
        object Selected_Item_Display { set; }
        List<object> Update_Item { get; }
        List<object> Items { set; }

        List<Tuple<string, object>> Selected_Query_Records { get; }

        event Action<string> ShowSelectedItem;
        event Action<string> GetItems;
        event Action<string, int> UpdateRecord;
    }
}
