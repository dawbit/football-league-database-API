using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Controls.InsertPanel
{
    public interface IInsertPanel
    {
        string Selected_Table { get; }

        List<object> Insert_Item { get; }
        List<object> Items { set; }
        List<Tuple<string, object>> Selected_Query_Records { get; }

        event Action<string> GetItems;
        event Action<string> InsertRecord;
    }
}
