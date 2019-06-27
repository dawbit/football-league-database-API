﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using application.DAL;
using System.Windows.Forms;
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
                return new object();
            }
            else
            {
                return new object();
            }
        }

        // Funkcje które wybierają listę graczy/klubów/trenerów/koszulek
        #region Players
        public List<Player> GetPlayers(List<Tuple<string, object>> QueryRecords)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>();

                string Query = $"select players.id ID, players.name Firstname, lastname Lastname," +
                    $"dateofbirth Dateofbirth, position Position, height Height, weight Weight, nationality Nationality, clubs.name Club" +
                    $" from players, clubs where players.club = clubs.id";

                List<Tuple<string, string, int>> columns = Columns.GetColumns("Players");

                for (int i = 0; i < QueryRecords.Count; i++)
                {
                    string AttributeName = QueryRecords[i].Item1.Replace(" ", string.Empty);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (columns[j].Item2 == QueryRecords[i].Item1)
                        {
                            par.Add("@" + AttributeName, QueryRecords[i].Item2);
                            Query += " and " + columns[j].Item1 + "=@" + AttributeName;
                        }
                    }  
                }

                List<Player> queryResult = _connection.GetPlayers(Query, par);

                _connection.CloseConnection();

                return queryResult;
            }
            else
            {
                return new List<Player>();
            }
        }
        #endregion

        #region Clubs
        public List<Club> GetClubs(List<Tuple<string, object>> QueryRecords)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>();

                string Query = $"select clubs.id ID, clubs.name Club, clubs.city City, clubs.founded Founded, clubs.active League from clubs";

                List<Tuple<string, string, int>> columns = Columns.GetColumns("Clubs");

                for (int i = 0; i < QueryRecords.Count; i++)
                {
                    string AttributeName = QueryRecords[i].Item1.Replace(" ", string.Empty);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (columns[j].Item2 == QueryRecords[i].Item1)
                        {
                            par.Add("@" + AttributeName, QueryRecords[i].Item2);
                            if ( i==0 ) Query += " where " + columns[j].Item1 + "=@" + AttributeName;
                            else Query += " and " + columns[j].Item1 + "=@" + AttributeName;
                        }
                    }
                }

                List<Club> queryResult = _connection.GetClubs(Query, par);

                _connection.CloseConnection();

                return queryResult;
            }
            else
            {
                return new List<Club>();
            }
        }
        #endregion

        #region Coaches
        public List<Coach> GetCoaches(List<Tuple<string, object>> QueryRecords)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>();

                string Query = $"select coaches.id ID, coaches.name Firstname, coaches.lastname Lastname," +
                    $"coaches.dateofbirth Dateofbirth, coaches.nationality Nationality, clubs.name Club from coaches, clubs where coaches.club = clubs.id";

                List<Tuple<string, string, int>> columns = Columns.GetColumns("Coaches");

                for (int i = 0; i < QueryRecords.Count; i++)
                {
                    string AttributeName = QueryRecords[i].Item1.Replace(" ", string.Empty);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (columns[j].Item2 == QueryRecords[i].Item1)
                        {
                            par.Add("@" + AttributeName, QueryRecords[i].Item2);
                            Query += " and " + columns[j].Item1 + "=@" + AttributeName;
                        }
                    }
                }

                List<Coach> queryResult = _connection.GetCoaches(Query, par);

                _connection.CloseConnection();

                return queryResult;
            }
            else
            {
                return new List<Coach>();
            }
        }
        #endregion

        #region Kits
        public List<Kit> GetKits(List<Tuple<string, object>> QueryRecords)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>();

                string Query = $"select kits.id ID, kits.home Homekit, kits.away Awaykit," +
                    $"kits.clubcolours Clubcolours, clubs.name Club from kits, clubs where kits.club = clubs.id";

                List<Tuple<string, string, int>> columns = Columns.GetColumns("Kits");

                for (int i = 0; i < QueryRecords.Count; i++)
                {
                    string AttributeName = QueryRecords[i].Item1.Replace(" ", string.Empty);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (columns[j].Item2 == QueryRecords[i].Item1)
                        {
                            par.Add("@" + AttributeName, QueryRecords[i].Item2);
                            Query += " and " + columns[j].Item1 + "=@" + AttributeName;
                        }
                    }
                }

                List<Kit> queryResult = _connection.GetKits(Query, par);

                _connection.CloseConnection();

                return queryResult;
            }
            else
            {
                return new List<Kit>();
            }
        }
        #endregion
    }
}