using application.Controls.SingleControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls
{
    class SharedFunctions
    {
        public static List<object> ObjectAttributeValues(object atype)
        {
            List<object> values = new List<object>();
            foreach (var prop in atype.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propertyName = prop.Name;
                var propertyValue = atype.GetType().GetProperty(propertyName).GetValue(atype, null);
                if (propertyName == "BirthDate" && DateTime.TryParse(propertyValue.ToString(), out DateTime date))
                    values.Add(date.ToString("dd-MM-yyyy"));
                else
                    values.Add(convertNullableToString(propertyValue));
            }
            return values;
        }

        //przekształca nulla na stringa
        private static string convertNullableToString(object property)
        {
            if (property == null) return string.Empty;
            else return property.ToString();
        }

        //dodaje kontrolki do edytowania po załadowaniu tabeli z comboboxa
        public static void AddEditControls(FlowLayoutPanel panel, string table)
        {
            panel.Controls.Clear();
            List<string> columnNames = Columns.ColumnNames(table);

            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i] == "Club")
                {
                    CustomComboBox club = new CustomComboBox();
                    club.Clubs();
                    panel.Controls.Add(club);
                }
                else if (columnNames[i] == "Position")
                {
                    CustomComboBox position = new CustomComboBox();
                    position.Position();
                    panel.Controls.Add(position);
                }
                else
                {
                    AttributeControlEdit attribute = new AttributeControlEdit();
                    attribute.AttributeName = columnNames[i];
                    panel.Controls.Add(attribute);
                }
            }
        }

        public static void AddEditableControls(int start_index, int[] RGB, FlowLayoutPanel panel, List<string> values, string table)
        {
            panel.Controls.Clear();
            List<string> columnNames = Columns.ColumnNames(table);
            // wypełnij tablicę pustymi stringami jeśli values jest puste
            if (!values.Any())
            {
                for (int i = 0; i < columnNames.Count; i++)
                    values.Add("");
            }

            for (int i = start_index; i < columnNames.Count; i++)
            {
                if (columnNames[i] == "Club")
                {
                    CustomComboBox club = new CustomComboBox();
                    club.Clubs();
                    club.BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
                    club.SetCurrentIndex = values[i];
                    panel.Controls.Add(club);
                }
                else if (columnNames[i] == "Position")
                {
                    CustomComboBox position = new CustomComboBox();
                    position.Position();
                    position.BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
                    position.SetCurrentIndex = values[i];
                    panel.Controls.Add(position);
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
    }
}
