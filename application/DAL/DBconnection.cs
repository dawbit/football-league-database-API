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

        public Player GetPlayer(string query, Dictionary<string, int> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, int> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    int Height;
                    int Weight;

                    if (dataReader["height"].ToString() == "") Height = 0;
                    else Height = int.Parse(dataReader["height"].ToString());

                    if (dataReader["weight"].ToString() == "") Weight = 0;
                    else Weight = int.Parse(dataReader["weight"].ToString());

                    return new Player(
                        int.Parse(dataReader["id"].ToString()),
                        dataReader["pname"].ToString(),
                        dataReader["lastname"].ToString(),
                        DateTime.Parse(dataReader["dateofbirth"].ToString()).Date,
                        dataReader["position"].ToString(),
                        Height,
                        Weight,
                        dataReader["nationality"].ToString(),
                        dataReader["cname"].ToString()
                    );
                }
                else return new Player();
            }
        }

        public List<Player> GetPlayers(string query)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Player> queryRecords = new List<Player>();

                while (dataReader.Read())
                {
                    int Height;
                    int Weight;

                    if (dataReader["height"].ToString() == "") Height = 0;
                    else Height = int.Parse(dataReader["height"].ToString());

                    if (dataReader["weight"].ToString() == "") Weight = 0;
                    else Weight = int.Parse(dataReader["weight"].ToString());

                    queryRecords.Add(new Player (
                        int.Parse(dataReader["id"].ToString()),
                        dataReader["pname"].ToString(),
                        dataReader["lastname"].ToString(),
                        DateTime.Parse(dataReader["dateofbirth"].ToString()).Date,
                        dataReader["position"].ToString(),
                        Height,
                        Weight,
                        dataReader["nationality"].ToString(),
                        dataReader["cname"].ToString()
                    ));
                }

                return queryRecords;
            }
        }
    }
}
