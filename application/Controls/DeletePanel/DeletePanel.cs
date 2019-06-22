using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.DeletePanel
{
    public partial class DeletePanel : UserControl, IDeletePanel
    {
        public DeletePanel()
        {
            InitializeComponent();
        }

        public string Selected_Table
        {
            get
            {
                return comboBoxTables.SelectedItem.ToString();
            }
        }

        public List<Tuple<string, string>> Selected_Item_Display
        {
            set
            {
                flowLayoutPanelShow.Controls.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    AttributeControlDisplay attribute = new AttributeControlDisplay();
                    attribute.AttributeName = value[i].Item1;
                    attribute.AttributValue = value[i].Item2;
                    flowLayoutPanelShow.Controls.Add(attribute);
                }
            }
        }
    }
}
