using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls
{
    class Columns
    {
        private static List<Tuple<string, int>> ClubColumns = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("ID", 60),
            new Tuple<string, int>("Name", 500),
            new Tuple<string, int>("City", 280),
            new Tuple<string, int>("Founded", 80),
            new Tuple<string, int>("League", 272)
        };
        private static List<Tuple<string, int>> PlayerColumns = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("ID", 60),
            new Tuple<string, int>("First name", 220),
            new Tuple<string, int>("Last name", 220),
            new Tuple<string, int>("Date of birth", 120),
            new Tuple<string, int>("Position", 100),
            new Tuple<string, int>("Height", 90),
            new Tuple<string, int>("Weight", 90),
            new Tuple<string, int>("Nationality", 100),
            new Tuple<string, int>("Club", 192)
        };
        private static List<Tuple<string, int>> CoachColumns = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("ID", 60),
            new Tuple<string, int>("First name", 300),
            new Tuple<string, int>("Last name", 300),
            new Tuple<string, int>("Date of birth", 180),
            new Tuple<string, int>("Nationality", 140),
            new Tuple<string, int>("Club", 212)
        };
        private static List<Tuple<string, int>> KitsColumns = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("ID", 60),
            new Tuple<string, int>("Home kit", 330),
            new Tuple<string, int>("Away kit", 330),
            new Tuple<string, int>("Club colours", 200),
            new Tuple<string, int>("Club", 272)
        };
        private static List<Tuple<string, int>> CrestsColumns = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("ID", 60),
            new Tuple<string, int>("Image", 549),
            new Tuple<string, int>("Club", 600)
        };
        private static List<Tuple<string, int>> StadiumColumns = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("ID", 60),
            new Tuple<string, int>("Name", 430),
            new Tuple<string, int>("City", 270),
            new Tuple<string, int>("Capacity", 190),
            new Tuple<string, int>("Club", 225)
        };

        public Columns() { }
        public static void AddColumns(ListView lv, string Table)
        {
            lv.Columns.Clear();
            List<Tuple<string, int>> columns = GetColumns(Table);
            for (int i = 0; i < columns.Count; i++)
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = columns[i].Item1;
                column.Width = columns[i].Item2;
                lv.Columns.Add(column);
            }
        }

        private static List<Tuple<string, int>> GetColumns(string TableName)
        {
            if (TableName == "Players") return PlayerColumns;
            else if (TableName == "Crests") return CrestsColumns;
            else if (TableName == "Coaches") return CoachColumns;
            else if (TableName == "Stadiums") return StadiumColumns;
            else if (TableName == "Kits") return KitsColumns;
            else if (TableName == "Clubs") return ClubColumns;
            else return new List<Tuple<string, int>>();
        }

        public static List<string> ColumnNames(ListView lv)
        {
            List<string> columnNames = new List<string>();
            foreach (ColumnHeader header in lv.Columns)
            {
                columnNames.Add(header.Text);
            }
            return columnNames;
        }
    }
}
