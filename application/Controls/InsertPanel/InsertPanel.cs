﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using application.Controls.SingleControls;
using System.Globalization;

namespace application.Controls.InsertPanel
{
    public partial class InsertPanel : UserControl, IInsertPanel
    {
        private ListViewColumnSorter lvwColumnSorter;

        public InsertPanel()
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
                    List<object> values = SharedFunctions.ObjectAttributeValues(value[i]);
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

        //do pobierania danych przy insercie z kontrolek wyświetlanych nad listview
        public List<object> Insert_Item
        {
            get
            {
                List<object> parameters = new List<object>();
                for (int i = 0; i < flowLayoutPanelInsert.Controls.Count; i++)
                {
                    if (flowLayoutPanelInsert.Controls[i] is AttributeControlEdit)
                    {
                        var obj = (AttributeControlEdit)flowLayoutPanelInsert.Controls[i];
                        if (DateTime.TryParseExact(obj.AttributeValue.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                            parameters.Add(date.ToString("yyyy-MM-dd"));
                        else parameters.Add(obj.AttributeValue);
                    }
                    else if (flowLayoutPanelInsert.Controls[i] is CustomComboBox)
                    {
                        var obj = (CustomComboBox)flowLayoutPanelInsert.Controls[i];
                        parameters.Add(obj.GetComboBoxIndex);
                    }
                }
                return parameters;
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
                        if (obj.Type == "Club") { if (obj.GetComboBoxIndex != 0) parameters.Add(new Tuple<string, object>("Club", obj.GetComboBoxIndex)); }
                        else if (obj.Type == "Position") { if (obj.GetComboBoxIndex != 0) parameters.Add(new Tuple<string, object>("Position", obj.GetComboBoxValue)); }
                    }
                }
                return parameters;
            }
        }


        public event Action<string> GetItems;
        public event Action<string> InsertRecord;

        //precyzuj zapytanie
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Selected_Table != "")
            {
                GetItems?.Invoke(Selected_Table);
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (Selected_Table != "")
            {
                if (Validate())
                {
                    InsertRecord?.Invoke(Selected_Table);
                    SharedFunctions.AddEditableControls(1, new int[] { 100, 136, 51 }, flowLayoutPanelInsert, new List<string>(), Selected_Table);
                }
                else
                {
                    MessageBox.Show("Values can't be null!");
                }
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

        //dodaje kontrolki do edytowania po załadowaniu tabeli z comboboxa
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelInsert.Controls.Clear();
            SharedFunctions.AddEditableControls(0, new int[] { 255, 47, 86 }, flowLayoutPanelSearch, new List<string>(), Selected_Table);
            SharedFunctions.AddEditableControls(1, new int[] { 100, 136, 51 }, flowLayoutPanelInsert, new List<string>(), Selected_Table);
        }

        #region PRIVATE FUNCTIONS
        //funkcja która pobiera wartości przechowywane przez publiczne pola obiektu gdy przekazujemy itemy do listview
        private bool Validate()
        {
            List<object> Records = Insert_Item;
            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].ToString() == "" || Records[i].ToString() == "0")
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
