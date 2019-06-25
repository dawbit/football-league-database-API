using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.DBdata;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace application.DAL
{
    class DBconnection
    {
        private readonly string _login;
        private readonly string _password;

        public MySqlConnection Connection { get; private set; }

        private DBconnection(string login, string password)
        {
            this._login = login;
            this._password = password;

            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder();
            connStrBuilder.Port = uint.Parse(DBinfo.port);
            connStrBuilder.UserID = _login;
            connStrBuilder.Password = _password;
            connStrBuilder.Server = DBinfo.server;
            connStrBuilder.Database = DBinfo.database;

            Connection = new MySqlConnection(connStrBuilder.ToString());
        }

        public static DBconnection Instance { get; private set; } = null;

        public static DBconnection Init(string login, string password)
        {
            Instance = new DBconnection(login, password);
            return Instance;
        }

        #region OPEN/CLOSE CONNECTIONS
        public bool OpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (MySqlException e)
            {
                return;
            }
        }
        #endregion

        public Player GetPlayer(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    int Height, Weight;

                    if (dataReader["Height"].ToString() == "") Height = 0;
                    else Height = int.Parse(dataReader["Height"].ToString());

                    if (dataReader["Weight"].ToString() == "") Weight = 0;
                    else Weight = int.Parse(dataReader["Weight"].ToString());

                    return new Player(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Firstname"].ToString(),
                        dataReader["Lastname"].ToString(),
                        DateTime.Parse(dataReader["Dateofbirth"].ToString()).Date,
                        dataReader["Position"].ToString(),
                        Height,
                        Weight,
                        dataReader["Nationality"].ToString(),
                        dataReader["Club"].ToString()
                    );
                }
                else return new Player();
            }
        }

        public List<Player> GetPlayers(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Player> queryRecords = new List<Player>();

                while (dataReader.Read())
                {
                    int Height, Weight;

                    if (dataReader["Height"].ToString() == "") Height = 0;
                    else Height = int.Parse(dataReader["Height"].ToString());

                    if (dataReader["Weight"].ToString() == "") Weight = 0;
                    else Weight = int.Parse(dataReader["Weight"].ToString());

                    queryRecords.Add(new Player (
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Firstname"].ToString(),
                        dataReader["Lastname"].ToString(),
                        DateTime.Parse(dataReader["Dateofbirth"].ToString()).Date,
                        dataReader["Position"].ToString(),
                        Height,
                        Weight,
                        dataReader["Nationality"].ToString(),
                        dataReader["Club"].ToString()
                    ));
                }

                return queryRecords;
            }
        }

        public Club GetClub(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                   return new Club(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Club"].ToString(),
                        dataReader["City"].ToString(),
                        short.Parse(dataReader["Founded"].ToString()),
                        dataReader["League"].ToString()
                    );
                }
                else return new Club();
            }
        }

        public List<Club> GetClubs(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Club> queryRecords = new List<Club>();

                while (dataReader.Read())
                {
                    queryRecords.Add(new Club(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Club"].ToString(),
                        dataReader["City"].ToString(),
                        short.Parse(dataReader["Founded"].ToString()),
                        dataReader["League"].ToString()
                    ));
                }

                return queryRecords;
            }
        }
    }
}
