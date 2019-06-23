using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Controls;
using System.Reflection;

namespace application.Controls.SelectPanel
{
    public partial class SelectPanel : UserControl, ISelectPanel
    {
        private ListViewColumnSorter lvwColumnSorter;

        public SelectPanel()
        {
            InitializeComponent();

            listViewItems.View = View.Details;
            listViewItems.MultiSelect = false;
            listViewItems.GridLines = true;
            listViewItems.FullRowSelect = true;

            ColumnHeader column = new ColumnHeader();
            column.Text = "";
            column.Width = 1192;
            listViewItems.Columns.Add(column);

            lvwColumnSorter = new ListViewColumnSorter();
            listViewItems.ListViewItemSorter = lvwColumnSorter;
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

        public List<List<string>> Items
        {
            get
            {
                return listViewItems.Items.OfType<List<string>>().ToList();
            }
            set
            {
                listViewItems.Items.Clear();
                Columns.AddColumns(listViewItems, Selected_Table);

                for (int i = 0; i < value.Count; i++)
                {
                    var listViewItem = new ListViewItem(value[i].ToArray());
                    listViewItems.Items.Add(listViewItem);
                }
            }
        }

        public int GetSelectedItemIndex
        {
            get
            {
                return int.Parse(listViewItems.SelectedItems[0].Text);
            }
        }

        public object Selected_Item_Display
        {
            set
            {
                flowLayoutPanelShow.Controls.Clear();
                List<string> columnNames = Columns.ColumnNames(listViewItems);
                List<object> values = ObjectAttributeValues(value);

                for (int i = 0; i < values.Count; i++)
                {
                    AttributeControlDisplay attribute = new AttributeControlDisplay();
                    attribute.AttributeName = columnNames[i];
                    attribute.AttributValue = values[i].ToString();
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

        public event Action<string> GetItems;
        public event Action<string, int> ShowSelectedItem;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Selected_Table != "")
            {
                GetItems?.Invoke(Selected_Table);
            }
        }

        private void listViewItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewItems.Columns[e.ColumnIndex].Width;
        }

        private void listViewItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.listViewItems.Sort();
        }

        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(GetSelectedItemIndex);
            if (ShowSelectedItem != null)
            {
                ShowSelectedItem(Selected_Table, GetSelectedItemIndex);
            }
        }

        public List<object> ObjectAttributeValues(object atype)
        {
            List<object> values = new List<object>();
            foreach (var prop in atype.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propertyName = prop.Name;
                var propertyValue = atype.GetType().GetProperty(propertyName).GetValue(atype, null);

                values.Add(convertNullableToString(propertyValue));
            }
            return values;
        }

        private string convertNullableToString(object property)
        {
            if (property == null) return string.Empty;
            else return property.ToString();
        }
    }
}
