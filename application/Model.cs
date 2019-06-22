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
        private readonly DBconnection _connection = DBconnection.Instance;

        //public List<string> GetPlayers(string table)
        //{
        //    Console.WriteLine("GETITEMS");
        //    List<string> players = new List<string>();

        //    if (_connection.OpenConnection())
        //    {
        //        using (var command = new MySqlCommand("select players.id, lastname, players.name pname, dateofbirth, " +
        //                            "position, height, weight, nationality, clubs.name cname from players, clubs where players.club = clubs.id;", _connection))
        //        {
        //            try
        //            {

        //                MySqlDataReader dataReader = command.ExecuteReader();

        //                while (dataReader.Read())
        //                {
        //                    players.Add(new Player(dataReader).ToString());
        //                }

        //                _connection.CloseConnection();
        //            }
        //            catch (MySqlException e)
        //            {
        //                Console.WriteLine("does not exist");
        //                return new List<string>().ToArray();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return new List<string>().ToArray();
        //    }

        //    foreach (string p in players)
        //        Console.WriteLine(p);

        //    return players.ToArray();
        //}

        public List<string> GetPlayers(string specialization)
        {
            if (_connection.OpenConnection())
            {
                List<string> queryResult = _connection.GetPlayers($"select players.id, lastname, players.name pname, dateofbirth, " +
                    $"position, height, weight, nationality, clubs.name cname from players, clubs where players.club = clubs.id");

                _connection.CloseConnection();
                return queryResult;
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
