﻿using System;
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

        //zwróc wybraną tabelę z comboboxa
        public string Selected_Table
        {
            get
            {
                if (comboBoxTables.SelectedIndex > -1)
                    return comboBoxTables.SelectedItem.ToString();
                else return "";
            }
        }

        //wyświetl dane w listview
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

        //zwróc indeks (z kolumny ID) z listview
        public int GetSelectedItemIndex
        {
            get
            {
                return int.Parse(listViewItems.SelectedItems[0].Text);
            }
        }

        //do wypisywania danych po naciśnięciu dwuklikiem
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

        //do pobierania wartości wpisywanych do customizowania zapytań przez użytkownika
        public List<Tuple<string, object>> Selected_Query_Records
        {
            get
            {
                List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();
                for (int i = 0; i < flowLayoutPanelSearch.Controls.Count; i++)
                {
                    if (flowLayoutPanelSearch.Controls[i] is AttributeControlEdit)
                    {
                        var obj = (AttributeControlEdit)flowLayoutPanelSearch.Controls[i];
                        if (obj.AttributeValue != "") parameters.Add(new Tuple<string, object>(obj.AttributeName, obj.AttributeValue));
                    }
                    else if (flowLayoutPanelSearch.Controls[i] is CustomComboBox)
                    {
                        var obj = (CustomComboBox)flowLayoutPanelSearch.Controls[i];
                        if (obj.GetClubIndex != 0) parameters.Add(new Tuple<string, object>("Club", obj.GetClubIndex));
                    }
                }
                return parameters;
            }
        }


        public event Action<string> GetItems;
        public event Action<string, int> ShowSelectedItem;

        //precyzuj zapytanie
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Selected_Table != "")
            {
                flowLayoutPanelShow.Controls.Clear();
                GetItems?.Invoke(Selected_Table);
            }
        }

        //zapobiega zmianie rozmiaru kolumn
        private void listViewItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewItems.Columns[e.ColumnIndex].Width;
        }

        //sortowanie kolumn
        private void listViewItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.listViewItems.Sort();
        }

        //dwuklik na itemie z listview
        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedItem?.Invoke(Selected_Table, GetSelectedItemIndex);
        }

        //dodaje kontrolki do edytowania po załadowaniu tabeli z comboboxa
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddEditControls();
        }

        #region PRIVATE FUNCTIONS
        //funkcja która pobiera wartości przechowywane przez publiczne pola obiektu gdy przekazujemy itemy do listview
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

        //przekształca nulla na stringa
        private string convertNullableToString(object property)
        {
            if (property == null) return string.Empty;
            else return property.ToString();
        }

        //dodaje kontrolki do edytowania po załadowaniu tabeli z comboboxa
        private void AddEditControls()
        {
            flowLayoutPanelSearch.Controls.Clear();
            List<string> columnNames = Columns.ColumnNames(Selected_Table);

            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i] == "Club")
                {
                    CustomComboBox club = new CustomComboBox();
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
        #endregion
    }
}
