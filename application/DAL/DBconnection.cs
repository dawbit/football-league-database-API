using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.DBdata;
using MySql.Data;
using MySql.Data.MySqlClient;
using static application.DBdata.Player;

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
            connStrBuilder.CharacterSet = "utf8mb4";
            Connection = new MySqlConnection(connStrBuilder.ToString());
        }

        public static DBconnection Instance { get; private set; } = null;

        public static DBconnection Init(string login, string password)
        {
            Instance = new DBconnection(login, password);
            return Instance;
        }

        public bool CreateUser(string query)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                try
                {
                    Connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    return true;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                    Connection.Close();
                    return false;
                }   
            }
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

        //zwróć dane o pojedyńczym graczu/graczach
        #region Player
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
                    Position Position;

                    if (dataReader["Height"].ToString() == "") Height = 0;
                    else Height = int.Parse(dataReader["Height"].ToString());

                    if (dataReader["Weight"].ToString() == "") Weight = 0;
                    else Weight = int.Parse(dataReader["Weight"].ToString());

                    if (dataReader["Position"].ToString() == "goalkeeper") { Position = Position.goalkeeper; }
                    else if (dataReader["Position"].ToString() == "defender") { Position = Position.defender; }
                    else if (dataReader["Position"].ToString() == "midfielder") { Position = Position.midfielder; }
                    else { Position = Position.striker; }

                    return new Player(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Firstname"].ToString(),
                        dataReader["Lastname"].ToString(),
                        DateTime.Parse(dataReader["Dateofbirth"].ToString()).Date,
                        Position,
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
                    Position Position;

                    if (dataReader["Height"].ToString() == "") Height = 0;
                    else Height = int.Parse(dataReader["Height"].ToString());

                    if (dataReader["Weight"].ToString() == "") Weight = 0;
                    else Weight = int.Parse(dataReader["Weight"].ToString());


                    if (dataReader["Position"].ToString() == "goalkeeper") { Position = Position.goalkeeper; }
                    else if (dataReader["Position"].ToString() == "defender") { Position = Position.defender; }
                    else if (dataReader["Position"].ToString() == "midfielder") { Position = Position.midfielder; }
                    else { Position = Position.striker; }

                    queryRecords.Add(new Player(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Firstname"].ToString(),
                        dataReader["Lastname"].ToString(),
                        DateTime.Parse(dataReader["Dateofbirth"].ToString()),
                        Position,
                        Height,
                        Weight,
                        dataReader["Nationality"].ToString(),
                        dataReader["Club"].ToString()
                    ));
                }

                return queryRecords;
            }
        }
        #endregion

        //zwróć dane o pojedyńczym klubie/klubach
        #region Club
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
        #endregion

        //zwróć dane o pojedyńczym trenerze/trenerach
        #region Coach
        public Coach GetCoach(string query, Dictionary<string, object> par)
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
                    return new Coach(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Firstname"].ToString(),
                        dataReader["Lastname"].ToString(),
                        DateTime.Parse(dataReader["Dateofbirth"].ToString()).Date,
                        dataReader["Nationality"].ToString(),
                        dataReader["Club"].ToString()
                    );
                }
                else return new Coach();
            }
        }

        public List<Coach> GetCoaches(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Coach> queryRecords = new List<Coach>();

                while (dataReader.Read())
                {
                    queryRecords.Add(new Coach(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Firstname"].ToString(),
                        dataReader["Lastname"].ToString(),
                        DateTime.Parse(dataReader["Dateofbirth"].ToString()).Date,
                        dataReader["Nationality"].ToString(),
                        dataReader["Club"].ToString()
                    ));
                }

                return queryRecords;
            }
        }
        #endregion

        //zwróć dane o pojedyńczym stroju/strojacch
        #region Kit
        public Kit GetKit(string query, Dictionary<string, object> par)
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
                    return new Kit(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Homekit"].ToString(),
                        dataReader["Awaykit"].ToString(),
                        dataReader["Clubcolours"].ToString(),
                        dataReader["Club"].ToString()
                    );
                }
                else return new Kit();
            }
        }

        public List<Kit> GetKits(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Kit> queryRecords = new List<Kit>();

                while (dataReader.Read())
                {
                    queryRecords.Add(new Kit(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Homekit"].ToString(),
                        dataReader["Awaykit"].ToString(),
                        dataReader["Clubcolours"].ToString(),
                        dataReader["Club"].ToString()
                    ));
                }

                return queryRecords;
            }
        }
        #endregion Kit

        #region Stadium
        public Stadium GetStadium(string query, Dictionary<string, object> par)
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
                    int Capacity, YearOfBuilt;

                    if (dataReader["Capacity"].ToString() == "") Capacity = 0;
                    else Capacity = int.Parse(dataReader["Capacity"].ToString());

                    if (dataReader["YearOfBuilt"].ToString() == "") YearOfBuilt = 0;
                    else YearOfBuilt = int.Parse(dataReader["YearOfBuilt"].ToString());

                    return new Stadium(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Name"].ToString(),
                        dataReader["City"].ToString(),
                        Capacity,
                        YearOfBuilt,
                        dataReader["Club"].ToString()
                    );
                }
                else return new Stadium();
            }
        }

        public List<Stadium> GetStadiums(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Stadium> queryRecords = new List<Stadium>();

                while (dataReader.Read())
                {
                    int Capacity, YearOfBuilt;

                    if (dataReader["Capacity"].ToString() == "") Capacity = 0;
                    else Capacity = int.Parse(dataReader["Capacity"].ToString());

                    if (dataReader["YearOfBuilt"].ToString() == "") YearOfBuilt = 0;
                    else YearOfBuilt = int.Parse(dataReader["YearOfBuilt"].ToString());

                    queryRecords.Add(new Stadium(
                        int.Parse(dataReader["ID"].ToString()),
                        dataReader["Name"].ToString(),
                        dataReader["City"].ToString(),
                        Capacity,
                        YearOfBuilt,
                        dataReader["Club"].ToString()
                    ));
                }

                return queryRecords;
            }
        }
        #endregion

        public bool InsertRecord(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                try
                {
                    // MySqlCommand.ExecuteNonQuery zwraca inta, oznacza on ilość wierszy które zostały dodane. My dodajemy pojedyńcze.
                    // Błąd w dodaniu rekordu wyrzuca Exception, stąd try catch
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }

        public bool UpdateRecord(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                try
                {
                    // MySqlCommand.ExecuteNonQuery zwraca inta, oznacza on ilość wierszy które zostały dodane. My dodajemy pojedyńcze.
                    // Błąd w dodaniu rekordu wyrzuca Exception, stąd try catch
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                catch (MySqlException e)
                {
                    return false;
                }
            }
        }

        public bool DeleteRecord(string query, Dictionary<string, object> par)
        {
            using (var cmd = new MySqlCommand(query, Connection))
            {
                foreach (KeyValuePair<string, object> p in par)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                try
                {
                    // MySqlCommand.ExecuteNonQuery zwraca inta, oznacza on ilość wierszy które zostały dodane. My dodajemy pojedyńcze.
                    // Błąd w dodaniu rekordu wyrzuca Exception, stąd try catch
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                catch (MySqlException e)
                {
                    return false;
                }
            }
        }
    }
}
