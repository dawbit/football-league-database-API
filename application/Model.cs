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

namespace application
{
    class Model
    {
        public string[] GetItems(string table)
        {
            Console.WriteLine("GETITEMS");
            List<string> players = new List<string>();

            MySqlConnection _connection = DBconnection.Instance.Connection;

            if (_connection != null && _connection.State == ConnectionState.Closed)
                _connection.Open();
            else
            {
                using (var command = new MySqlCommand("select players.id, lastname, players.name pname, dateofbirth, " +
                    "position, height, weight, nationality, clubs.name cname from players, clubs where players.club = clubs.id;", _connection))
                {
                    try
                    {

                        MySqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            players.Add(new Player(dataReader).ToString());
                        }

                        _connection.Close();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine("does not exist");
                        return new List<string>().ToArray();
                    }
                }
            }


            foreach (string p in players)
                Console.WriteLine(p);

            return players.ToArray();
        }
    }
}
