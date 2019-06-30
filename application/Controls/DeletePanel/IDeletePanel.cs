using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controls.DeletePanel
{
    public interface IDeletePanel
    {
        string Selected_Table { get; }
        object Selected_Item_Display { set; }
        int GetSelectedItemIndex { get; }
        List<object> Items { set; }
        List<Tuple<string, object>> Selected_Query_Records { get; }

        event Action<string> GetItems;
        event Action<string> ShowSelectedItem;
        event Action<string, int> DeleteRecord;
    }
}
