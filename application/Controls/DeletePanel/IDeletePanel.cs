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
        List<Tuple<string, string>> Selected_Item_Display { set; }
    }
}
