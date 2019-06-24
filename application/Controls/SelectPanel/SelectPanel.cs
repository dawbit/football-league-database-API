using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Controls.SingleControls;
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

        public List<object> Items
        {
            set
            {
                listViewItems.Items.Clear();
                Columns.AddColumns(listViewItems, Selected_Table);
                for (int i = 0; i < value.Count; i++)
                {
                    List<object> values = ObjectAttributeValues(value[i]);
                    var listViewItem = new ListViewItem(values.Select(j => j.ToString()).ToArray());
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
                List<string> columnNames = Columns.ColumnNames(Selected_Table);
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

        public List<Tuple<string, string>> Selected_Items_Show
        {
            get
            {
                List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();
                for (int i = 0; i < flowLayoutPanelSearch.Controls.Count; i++)
                {
                    if (flowLayoutPanelSearch.Controls[i] is AttributeControlEdit)
                    {
                        var obj = (AttributeControlEdit)flowLayoutPanelSearch.Controls[i];
                        if (obj.AttributeValue != "")
                        {
                            Console.WriteLine(obj.AttributeName, obj.AttributeValue.ToString());
                            //parameters.Add(Tuple.Create<string, string>(obj.AttributeName, obj.AttributeValue.ToString()));
                        }
                    }
                    //else
                    //if (flowLayoutPanelSearch.Controls[i] is ComboBoxClubs)
                    //{
                    //    var obj = (ComboBoxClubs)flowLayoutPanelSearch.Controls[i];
                    //    if (obj.GetClubIndex != 0)
                    //    {
                    //        //Console.WriteLine(obj.GetClubIndex.ToString());
                    //        parameters.Add(new Tuple<string, string>("Club", 2.ToString()));
                    //    }
                    //}
                }

                return parameters;
            }
        }

        public event Action<string> GetItems;
        public event Action<string, int> ShowSelectedItem;

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            List<Tuple<string, string>> parameters = Selected_Items_Show;
            //for (int i = 0; i < parameters.Count; i++)
            //{
            //    Console.WriteLine(":(");
            //    Console.WriteLine(parameters[i].Item1, parameters[i].Item2);
            //}

            if (Selected_Table != "")
            {
                //List<Tuple<string, string>> parameters = Selected_Items_Show;
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
            if (ShowSelectedItem != null)
            {
                ShowSelectedItem(Selected_Table, GetSelectedItemIndex);
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddEditControls();
        }

        private List<object> ObjectAttributeValues(object atype)
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

        private void AddEditControls()
        {
            flowLayoutPanelSearch.Controls.Clear();
            List<string> columnNames = Columns.ColumnNames(Selected_Table);

            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i] == "Club")
                {
                    ComboBoxClubs club = new ComboBoxClubs();
                    flowLayoutPanelSearch.Controls.Add(club);
                }
                else
                {
                    AttributeControlEdit attribute = new AttributeControlEdit();
                    attribute.AttributeName = columnNames[i];
                    flowLayoutPanelSearch.Controls.Add(attribute);
                }
            }
        }
    }
}
