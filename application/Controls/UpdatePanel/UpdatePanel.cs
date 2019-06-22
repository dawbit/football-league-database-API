using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.UpdatePanel
{
    public partial class UpdatePanel : UserControl, IUpdatePanel
    {
        public UpdatePanel()
        {
            InitializeComponent();

            listViewItems.View = View.Details;
            listViewItems.MultiSelect = false;
            listViewItems.GridLines = true;
            listViewItems.FullRowSelect = true;
            listViewItems.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        }

        public string Selected_Table
        {
            get
            {
                if (comboBoxTables.SelectedIndex > -1)
                    return comboBoxTables.SelectedItem.ToString();
                else return "";
            }
        }

        public List<Tuple<string, string>> Selected_Item_Edit
        {
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
