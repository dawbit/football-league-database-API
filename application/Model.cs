using System;
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

        private bool IsNumber(string s)
        {
            int n;
            if (int.TryParse(s, out n)) return true;
            else return false;
        }

        #region Players
        public Player GetPlayer(int id)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>()
                {
                    { "@id", id }
                };

                Player result = _connection.GetPlayer($"select players.id ID, players.name Firstname, lastname Lastname," +
                    $"dateofbirth Dateofbirth, position Position, height Height, weight Weight, nationality Nationality, clubs.name Club" +
                    $" from players, clubs where players.club = clubs.id and players.id=@id", par);
                _connection.CloseConnection();
                return result;
            }
            else
            {
                return new Player();
            }
        }
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
        public Club GetClub(int id)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, object> par = new Dictionary<string, object>()
                {
                    { "@id", id }
                };

                Club result = _connection.GetClub($"select clubs.id ID, clubs.name Club, clubs.city City, clubs.founded Founded, clubs.active League from clubs where clubs.id=@id", par);
                _connection.CloseConnection();
                return result;
            }
            else
            {
                return new Club();
            }
        }
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
    }
}
