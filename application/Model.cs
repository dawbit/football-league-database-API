using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using application.DAL;
using application.Controls.SelectPanel;
using application.DBdata;
using System.Data;
using application.Controls;

namespace application
{
    class Model
    {
        private readonly DBconnection _connection = DBconnection.Instance;

        // funkcja która zwraca pojedyńczy obiekt do wyświetlania dwuklikiem
        public object GetItem(int id, string table)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>()
                {
                    { "@id", id }
                };

                if (table == "Players")
                {
                    object result = _connection.GetPlayer($"select players.id ID, players.name Firstname, lastname Lastname," +
                        $"dateofbirth Dateofbirth, position Position, height Height, weight Weight, nationality Nationality, clubs.name Club" +
                        $" from players, clubs where players.club = clubs.id and players.id=@id", par);

                    _connection.CloseConnection();
                    return result;
                }
                else if (table == "Clubs")
                {
                    object result = _connection.GetClub($"select clubs.id ID, clubs.name Club, clubs.city City," +
                        $" clubs.founded Founded, clubs.active League from clubs where clubs.id=@id", par);
                    _connection.CloseConnection();
                    return result;
                }
                else if (table == "Kits")
                {
                    object result = _connection.GetKit($"select kits.id ID, kits.home Homekit, kits.away Awaykit," +
                        $"kits.clubcolours Clubcolours, clubs.name Club from kits, clubs where kits.club = clubs.id and kits.id=@id", par);

                    _connection.CloseConnection();
                    return result;
                }
                else if (table == "Coaches")
                {
                    object result = _connection.GetCoach($"select coaches.id ID, coaches.name Firstname, coaches.lastname Lastname," +
                        $"coaches.dateofbirth Dateofbirth, coaches.nationality Nationality, clubs.name Club from coaches, clubs where coaches.club = clubs.id and coaches.id=@id", par);

                    _connection.CloseConnection();
                    return result;
                }
                else if (table == "Stadiums")
                {
                    object result = _connection.GetStadium($"SELECT stadiums.id ID, stadiums.name Name, stadiums.city City, " +
                        $"stadiums.capacity Capacity, stadiums.buildyear YearOfBuilt, clubs.name Club FROM stadiums " +
                        $"JOIN clubs_has_stadiums JOIN clubs WHERE clubs_id_clubs = clubs.id " +
                        $"AND stadiums_id_stadiums = stadiums.id and stadiums.id = @id ", par);

                    _connection.CloseConnection();
                    return result;
                }
                return new object();
            }
            else
            {
                return new object();
            }
        }

        public List<object> GetItems(List<Tuple<string, object>> QueryRecords, string table)
        {
            if (_connection.OpenConnection())
            {
                // definiujemy bazowe zapytanie do tabeli
                string Query = "";
                if (table == "Players")
                {
                    Query = $"select players.id ID, players.name Firstname, lastname Lastname," +
                    $"dateofbirth Dateofbirth, position Position, height Height, weight Weight, nationality Nationality, clubs.name Club" +
                    $" from players, clubs where players.club = clubs.id";
                }
                else if (table == "Clubs")
                {
                    Query = $"select clubs.id ID, clubs.name Club, clubs.city City, clubs.founded Founded, clubs.active League from clubs";
                }
                else if (table == "Kits")
                {
                    Query = $"select kits.id ID, kits.home Homekit, kits.away Awaykit," +
                        $"kits.clubcolours Clubcolours, clubs.name Club from kits, clubs where kits.club = clubs.id";
                }
                else if (table == "Coaches")
                {
                    Query = $"select coaches.id ID, coaches.name Firstname, coaches.lastname Lastname," +
                        $"coaches.dateofbirth Dateofbirth, coaches.nationality Nationality, clubs.name Club from coaches, clubs where coaches.club = clubs.id";
                }
                else if (table == "Stadiums")
                {
                    Query = $"SELECT stadiums.id ID, stadiums.name Name, stadiums.city City, +"
                                    + $"stadiums.capacity Capacity, stadiums.buildyear YearOfBuilt, clubs.name Club FROM stadiums "
                                    + $"JOIN clubs_has_stadiums JOIN clubs WHERE clubs_id_clubs = clubs.id AND stadiums_id_stadiums = stadiums.id";
                }

                //wywołujemy funkcję która zwraca nam uzupełnione zapytanie (Item1), oraz Dictionary dla wywoływanych funkcji z DBconnection
                Tuple<string, Dictionary<string, object>> fullData = FillDictionaryAndQuery(table, Query, QueryRecords);

                List<object> queryResult = new List<object>();
                if (table == "Players") queryResult = _connection.GetPlayers(fullData.Item1, fullData.Item2).Cast<object>().ToList();
                else if (table == "Clubs") queryResult = _connection.GetClubs(fullData.Item1, fullData.Item2).Cast<object>().ToList();
                else if (table == "Kits") queryResult = _connection.GetKits(fullData.Item1, fullData.Item2).Cast<object>().ToList();
                else if (table == "Coaches") queryResult = _connection.GetCoaches(fullData.Item1, fullData.Item2).Cast<object>().ToList();
                else if (table == "Stadiums") queryResult = _connection.GetStadiums(fullData.Item1, fullData.Item2).Cast<object>().ToList();

                _connection.CloseConnection();

                return queryResult;
            }
            else
            {
                return new List<object>();
            }
        }

        public bool InsertRecord(List<object> values, string table)
        {
            if (_connection.OpenConnection())
            {
                string Query = "";
                Dictionary<string, object> par = new Dictionary<string, object>();
                if (table == "Players")
                {
                    try
                    {
                        DateTime date = DateTime.Parse(values[2].ToString());

                        par = new Dictionary<string, object>
                        {
                            { "@name", values[0] },
                            { "@lastname", values[1] },
                            { "@dateofbirth", date.ToString("yyyy-MM-dd") },
                            { "@position",  values[3] },
                            { "@height", values[4] },
                            { "@weight", values[5] },
                            { "@nationality", values[6] },
                            { "@club",  values[7] }
                        };
                        // UPDATE players SET name=@name WHERE

                        Query = $"insert into players (name, lastname, dateofbirth, position, height, weight, nationality, club) " +
                            $"values (@name, @lastname, @dateofbirth, @position, @height, @weight, @nationality, @club)";
                    }
                    catch { return false; }
                }
                else if (table == "Clubs")
                {
                    par = new Dictionary<string, object>
                    {
                        { "@name", values[0] },
                        { "@city", values[1] },
                        { "@founded", values[2] },
                        { "@active",  values[3] }
                    };

                    Query = $"insert into clubs (name, city, founded, active) values (@name, @city, @founded, @active)";
                }
                else if (table == "Kits")
                {
                    par = new Dictionary<string, object>
                    {
                        { "@home", values[0] },
                        { "@away", values[1] },
                        { "@clubcolours",  values[2] },
                        { "@club", values[3] }
                    };

                    Query = $"insert into kits (home, away, clubcolours, club) values (@home, @away, @clubcolours, @club)";
                }
                else if (table == "Coaches")
                {
                    try
                    {
                        DateTime date = DateTime.Parse(values[2].ToString());

                        par = new Dictionary<string, object>
                        {
                            { "@name", values[0] },
                            { "@lastname", values[1] },
                            { "@dateofbirth", date.ToString("yyyy-MM-dd") },
                            { "@nationality", values[3] },
                            { "@club",  values[4] }
                        };
                        // UPDATE players SET name=@name WHERE
                        Query = $"insert into coaches (name, lastname, dateofbirth, nationality, club) values " +
                                                $"(@name, @lastname, @dateofbirth, @nationality, @club)";
                    }
                    catch { return false; }
                }
                else if (table == "Stadiums")
                {
                    par = new Dictionary<string, object>
                    {
                        { "@name", values[0] },
                        { "@city", values[1] },
                        { "@capacity", values[2] },
                        { "@buildyear",  values[3] }
                    };

                    Query = $"insert into stadiums (name, city, capacity, buildyear) values (@name, @city, @capacity, @buildyear)";
                }

                bool result = _connection.InsertRecord(Query, par);
                return result;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRecord(List<object> values, string table, int id)
        {
            if (_connection.OpenConnection())
            {
                string Query = "";
                Dictionary<string, object> par = new Dictionary<string, object>();
                if (table == "Players")
                {
                    try
                    {
                        DateTime date = DateTime.Parse(values[2].ToString());

                        par = new Dictionary<string, object>
                        {
                            { "@id", id },
                            { "@name", values[0] },
                            { "@lastname", values[1] },
                            { "@dateofbirth", date.ToString("yyyy-MM-dd") },
                            { "@position",  values[3] },
                            { "@height", values[4] },
                            { "@weight", values[5] },
                            { "@nationality", values[6] },
                            { "@club",  values[7] }
                        };
                        // UPDATE players SET name=@name WHERE
                        Query = $"UPDATE players SET name=@name, lastname=@lastname, dateofbirth=@dateofbirth, position=@position, " +
                            $"height=@height, weight=@weight, nationality=@nationality, club=@club WHERE id=@id";
                    }
                    catch { return false; }
                }
                else if (table == "Clubs")
                {
                    par = new Dictionary<string, object>
                    {
                        { "@id", id },
                        { "@name", values[0] },
                        { "@city", values[1] },
                        { "@founded", values[2] },
                        { "@active",  values[3] }
                    };

                    Query = $"UPDATE clubs SET name=@name, city=@city, founded=@founded, active=@active WHERE id=@id";
                }
                else if (table == "Kits")
                {
                    par = new Dictionary<string, object>
                    {
                        { "@id", id },
                        { "@home", values[0] },
                        { "@away", values[1] },
                        { "@clubcolours",  values[2] },
                        { "@club", values[3] }
                    };

                    Query = $"UPDATE kits SET home=@home, away=@away, clubcolours=@clubcolours, club=@club WHERE id=@id";
                }
                else if (table == "Coaches")
                {
                    try
                    {
                        DateTime date = DateTime.Parse(values[2].ToString());

                        par = new Dictionary<string, object>
                        {
                            { "@id", id },
                            { "@name", values[0] },
                            { "@lastname", values[1] },
                            { "@dateofbirth", date.ToString("yyyy-MM-dd") },
                            { "@nationality", values[3] },
                            { "@club",  values[4] }
                        };
                        // UPDATE players SET name=@name WHERE
                        Query = $"UPDATE coaches SET name=@name, lastname=@lastname, dateofbirth=@dateofbirth, nationality=@nationality, club=@club WHERE id=@id";
                    }
                    catch { return false; } }
                else if (table == "Stadiums")
                {
                    par = new Dictionary<string, object>
                    {
                        { "@id", id },
                        { "@name", values[0] },
                        { "@city", values[1] },
                        { "@capacity", values[2] },
                        { "@buildyear",  values[3] }
                    };

                    Query = $"UPDATE stadiums SET name=@name, city=@city, capacity=@capacity, buildyear=@buildyear WHERE id=@id";
                }

                bool result = _connection.UpdateRecord(Query, par);
                return result;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteRecord(string table, int id)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>()
                {
                    { "@id", id }
                };

                string Query = $"DELETE from {table.ToLower()} WHERE id=@id";
                bool result = _connection.DeleteRecord(Query, par);
                return result;
            }
            else
            {
                return false;
            }
        }

        // prywatna funkcja, otrzymuje tablice, zapytanie i rekordy według których ma szukać
        // zwraca uzupełnione rekordy według tablicy (Clubs nie ma dopasowania po id więc trzeba zrobić dodatkowe where), uzupełniony słownik o wartości po
        // których ma szukać
        private Tuple<string, Dictionary<string, object>> FillDictionaryAndQuery (string table, string Query, List<Tuple<string, object>> QueryRecords)
        {
            Dictionary<string, object> par = new Dictionary<string, object>();
            List<Tuple<string, string, int>> columns = Columns.GetColumns(table);

            if (table == "Clubs")
            {
                for (int i = 0; i < QueryRecords.Count; i++)
                {
                    string AttributeName = QueryRecords[i].Item1.Replace(" ", string.Empty);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (columns[j].Item2 == QueryRecords[i].Item1)
                        {
                            par.Add("@" + AttributeName, QueryRecords[i].Item2);
                            if (i == 0) Query += " where " + columns[j].Item1 + "=@" + AttributeName;
                            else Query += " and " + columns[j].Item1 + "=@" + AttributeName;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < QueryRecords.Count; i++)
                {
                    string AttributeName = QueryRecords[i].Item1.Replace(" ", string.Empty);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (columns[j].Item2 == QueryRecords[i].Item1)
                        {
                            if (AttributeName == "Club")
                            {
                                par.Add("@" + AttributeName, QueryRecords[i].Item2);
                                Query += " and " + columns[j].Item1 + "=@" + AttributeName;
                            }
                            else
                            {
                                par.Add("@" + AttributeName, QueryRecords[i].Item2 + "%");
                                Query += " and " + columns[j].Item1 + " LIKE @" + AttributeName;
                            }
                        }
                    }
                }
            }
            return new Tuple<string, Dictionary<string, object>>(Query, par);
        }
    }
}