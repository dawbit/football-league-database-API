using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.SelectPanel
{
    public partial class SelectPanel : UserControl, ISelectPanel
    {
        public SelectPanel()
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

        public List<Tuple<string, string>> Selected_Item_Edit
        {
            get
            {
                List<Tuple<string, string>> items = new List<Tuple<string, string>>();
                foreach (AttributeControlEdit obj in flowLayoutPanelSearch.Controls)
                {
                    if (obj.AttributeValue != "")
                    {
                        //var item = new
                        //items.Add(item.GetInfo());
                    }
                }
                return items;
            }
            set
            {
                flowLayoutPanelSearch.Controls.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    AttributeControlEdit attribute = new AttributeControlEdit();
                    attribute.AttributeName = value[i].Item1;
                    attribute.AttributeValue = value[i].Item2;
                    flowLayoutPanelSearch.Controls.Add(attribute);
                }
            }
        }
    }
}
