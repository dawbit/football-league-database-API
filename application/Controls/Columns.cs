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
        //tuple, zawierają nazwy kolumn odpowiednich tabel z mysql, nazwy kolumn które mają być wyświetlane w lsitview i ich rozmiar
        private static List<Tuple<string, string, int>> ClubColumns = new List<Tuple<string, string, int>>
        {
            new Tuple<string, string, int>("clubs.id", "ID", 60),
            new Tuple<string, string, int>("clubs.name", "Name", 500),
            new Tuple<string, string, int>("clubs.city", "City", 280),
            new Tuple<string, string, int>("clubs.founded", "Founded", 80),
            new Tuple<string, string, int>("clubs.active", "League", 272)
        };
        private static List<Tuple<string, string, int>> PlayerColumns = new List<Tuple<string, string, int>>
        {
            new Tuple<string, string, int>("players.id", "ID", 60),
            new Tuple<string, string, int>("players.name", "First name", 220),
            new Tuple<string, string, int>("players.lastname", "Last name", 220),
            new Tuple<string, string, int>("players.dateofbirth", "Date of birth", 120),
            new Tuple<string, string, int>("players.position", "Position", 100),
            new Tuple<string, string, int>("players.height", "Height", 90),
            new Tuple<string, string, int>("players.weight", "Weight", 90),
            new Tuple<string, string, int>("players.nationality", "Nationality", 100),
            new Tuple<string, string, int>("clubs.id", "Club", 192)
        };
        private static List<Tuple<string, string, int>> CoachColumns = new List<Tuple<string, string, int>>
        {
            new Tuple<string, string, int>("coaches.id", "ID", 60),
            new Tuple<string, string, int>("coaches.name", "First name", 300),
            new Tuple<string, string, int>("coaches.lastname", "Last name", 300),
            new Tuple<string, string, int>("coaches.dateofbirth", "Date of birth", 180),
            new Tuple<string, string, int>("coaches.nationality", "Nationality", 140),
            new Tuple<string, string, int>("clubs.id", "Club", 212)
        };
        private static List<Tuple<string, string, int>> KitsColumns = new List<Tuple<string, string, int>>
        {
            new Tuple<string, string, int>("kits.id","ID", 60),
            new Tuple<string, string, int>("kits.home", "Home kit", 330),
            new Tuple<string, string, int>("kits.away", "Away kit", 330),
            new Tuple<string, string, int>("kits.clubcolours", "Club colours", 200),
            new Tuple<string, string, int>("clubs.id" ,"Club", 272)
        };
        private static List<Tuple<string, string, int>> CrestsColumns = new List<Tuple<string, string, int>>
        {
            new Tuple<string, string, int>("crests.id","ID", 60),
            new Tuple<string, string, int>("crests.image", "Image", 549),
            new Tuple<string, string, int>("clubs.id" ,"Club", 600)
        };
        private static List<Tuple<string, string, int>> StadiumColumns = new List<Tuple<string, string, int>>
        {
            new Tuple<string, string, int>("stadiums.id", "ID", 60),
            new Tuple<string, string, int>("stadiums.name", "Name", 430),
            new Tuple<string, string, int>("stadiums.city", "City", 270),
            new Tuple<string, string, int>("stadiums.capacity", "Capacity", 190),
            new Tuple<string, string, int>("clubs.id" ,"Club", 225)
        };

        public Columns() { }

        //dodaj kolumny w listview
        public static void AddColumns(ListView lv, string Table)
        {
            lv.Columns.Clear();
            List<Tuple<string, string, int>> columns = GetColumns(Table);
            for (int i = 0; i < columns.Count; i++)
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = columns[i].Item2;
                column.Width = columns[i].Item3;
                lv.Columns.Add(column);
            }
        }

        //zwróc całe tuple, zrobione by zwracać nazwy kolumn w sql do podzapytań w modelu
        public static List<Tuple<string, string, int>> GetColumns(string TableName)
        {
            if (TableName == "Players") return PlayerColumns;
            else if (TableName == "Crests") return CrestsColumns;
            else if (TableName == "Coaches") return CoachColumns;
            else if (TableName == "Stadiums") return StadiumColumns;
            else if (TableName == "Kits") return KitsColumns;
            else if (TableName == "Clubs") return ClubColumns;
            else return new List<Tuple<string, string, int>>();
        }

        //zwróc nazwy kolumn
        public static List<string> ColumnNames(string TableName)
        {
            List<string> columnNames = new List<string>();

            if (TableName == "Players")
            {
                for (int i = 0; i < PlayerColumns.Count; i++)
                {
                    columnNames.Add(PlayerColumns[i].Item2);
                }
            }
            else if (TableName == "Crests")
            {
                for (int i = 0; i < CrestsColumns.Count; i++)
                {
                    columnNames.Add(CrestsColumns[i].Item2);
                }
            }
            else if (TableName == "Coaches")
            {
                for (int i = 0; i < CoachColumns.Count; i++)
                {
                    columnNames.Add(CoachColumns[i].Item2);
                }
            }
            else if (TableName == "Stadiums")
            {
                for (int i = 0; i < StadiumColumns.Count; i++)
                {
                    columnNames.Add(StadiumColumns[i].Item2);
                }
            }
            else if (TableName == "Kits")
            {
                for (int i = 0; i < KitsColumns.Count; i++)
                {
                    columnNames.Add(KitsColumns[i].Item2);
                }
            }
            else if (TableName == "Clubs")
            {
                for (int i = 0; i < ClubColumns.Count; i++)
                {
                    columnNames.Add(ClubColumns[i].Item2);
                }
            }

            return columnNames;
        }
    }
}
