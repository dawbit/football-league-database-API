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
        DBconnection _conn = DBconnection.Instance();
        MySqlConnection _connection;

        private string Query;

        public string AccountType(string login, string password)
        {
            Query = $"INSERT INTO ekstraklasa.logs(user, date) VALUES(\"{login}\", \"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\")";
            Console.WriteLine("QUERY: " + Query);

            try
            {
                _conn = DBconnection.Init(login, password);
                _connection = _conn.Connection;

                MySqlCommand command = new MySqlCommand(Query, _connection);

                using (command)
                {
                    _connection.Open();

                    var dataReader = command.ExecuteNonQuery();

                    _connection.Close();

                    if (dataReader > 1) return "connUnsuccessful";
                    else if (dataReader == 1) return "administrator";
                    else return "user";
                }
            } catch(MySqlException e)
            {
                return e.ToString();
            }
        }
    }
}
