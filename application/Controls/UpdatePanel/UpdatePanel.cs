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

namespace application.Controls.UpdatePanel
{
    public partial class UpdatePanel : UserControl, IUpdatePanel
    {
        private ListViewColumnSorter lvwColumnSorter;

        // SelectedItemIndex przechowuje index aktualnie edytowanego itemu w InsertPanel, ponieważ GetSeletedItemIndex zwraca
        // index wyłączenie zaznaczonego itemu w listview, a nie tego który jest wywołany dwuklikiem
        private int SelectedItemIndex;

        public UpdatePanel()
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

        //do pobierania danych przy insercie z kontrolek wyświetlanych nad listview
        public List<object> Update_Item
        {
            get
            {
                List<object> parameters = new List<object>();
                for (int i = 0; i < flowLayoutPanelUpdate.Controls.Count; i++)
                {
                    if (flowLayoutPanelUpdate.Controls[i] is AttributeControlEdit)
                    {
                        var obj = (AttributeControlEdit)flowLayoutPanelUpdate.Controls[i];
                        parameters.Add(obj.AttributeValue);
                    }
                    else if (flowLayoutPanelUpdate.Controls[i] is CustomComboBox)
                    {
                        var obj = (CustomComboBox)flowLayoutPanelUpdate.Controls[i];
                        parameters.Add(obj.GetClubIndex);
                    }
                }
                return parameters;
            }
        }

        public object Selected_Item_Display
        {
            set
            {
                List<object> values = ObjectAttributeValues(value);
                AddEditableControls(1, new int[] { 68, 47, 130 }, flowLayoutPanelUpdate, values.Cast<string>().ToList());
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

        public event Action<string> ShowSelectedItem;  //uzupełnij kontrolki nad listview
        public event Action<string> GetItems;     //listview
        public event Action<string, int> UpdateRecord; //button

        //precyzuj zapytanie
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Selected_Table != "")
            {
                GetItems?.Invoke(Selected_Table);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (Selected_Table != "")
            {
                if (Validate())
                {
                    UpdateRecord?.Invoke(Selected_Table, SelectedItemIndex);
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

        //dwuklik na itemie z listview
        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedItem?.Invoke(Selected_Table);
            // SelectedItemIndex przechowuje index aktualnie edytowanego itemu w InsertPanel, ponieważ GetSeletedItemIndex zwraca
            // index wyłączenie zaznaczonego itemu w listview, a nie tego który jest wywołany dwuklikiem
            SelectedItemIndex = GetSelectedItemIndex;
        }

        //dodaje kontrolki do edytowania po załadowaniu tabeli z comboboxa
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddEditableControls(0, new int[] { 255, 47, 86 }, flowLayoutPanelSearch, new List<string>());
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
        private void AddEditableControls(int start_index, int[] RGB, FlowLayoutPanel panel, List<string> values)
        {
            panel.Controls.Clear();
            List<string> columnNames = Columns.ColumnNames(Selected_Table);
            // wypełnij tablicę pustymi stringami jeśli values jest puste
            if (!values.Any()) {
                for (int i = 0; i < columnNames.Count; i++)
                    values.Add("");
            }

            for (int i = start_index; i < columnNames.Count; i++)
            {
                if (columnNames[i] == "Club")
                {
                    CustomComboBox club = new CustomComboBox();
                    club.BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
                    club.SetCurrentIndex = values[i];
                    panel.Controls.Add(club);
                }
                else
                {
                    AttributeControlEdit attribute = new AttributeControlEdit();
                    attribute.BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
                    attribute.AttributeName = columnNames[i];
                    attribute.AttributeValue = values[i];
                    panel.Controls.Add(attribute);
                }
            }
        }

        private bool Validate()
        {
            List<object> Records = Update_Item;
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
