using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using application.DAL;

namespace application
{
    class Model
    {
        DBconnection _conn;
        MySqlConnection _connection;

        private string Query;

        public string AccountType(string login, string password)
        {
            string Query = $"SELECT user, insert_priv FROM mysql.user WHERE user = \"{login}\"";

            _conn = DBconnection.Init(login, password);
            _connection = _conn.Connection;

            MySqlCommand command = new MySqlCommand(Query, _connection);

            using (command)
            {
                try
                {
                    _connection.Open();

                    MySqlDataReader dataReader = command.ExecuteReader();

                    List<string> _result = new List<string>();

                    while (dataReader.Read())
                    {
                        _result.Add((string)dataReader["insert_priv"]);
                    }

                    _connection.Close();

                    if (_result.Count > 1) return "connUnsuccessful";
                    else if (_result[0] == "N") return "user";
                    else return "administrator";
                }
                catch (MySqlException)
                {
                    return "connUnsuccessful";
                }
            }
        }
    }
}
